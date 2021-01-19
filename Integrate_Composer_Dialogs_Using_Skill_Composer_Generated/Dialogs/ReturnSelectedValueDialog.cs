using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialog_Using_Skill_Composer_Generated.Dialogs
{
    public class ReturnSelectedValueDialog : ComponentDialog
    {
        public ReturnSelectedValueDialog() : base(nameof(ReturnSelectedValueDialog))
        {
            InitializeWaterfallDialog();
        }

        public WaterfallStepContext StepContext { get; private set; }

        private void InitializeWaterfallDialog()
        {
            var waterFallSteps = new WaterfallStep[]
            {
                SelectValueStepAsync,
                FinalStepAsync
            };

            AddDialog(new WaterfallDialog($"{nameof(ReturnSelectedValueDialog)}.mainFlow", waterFallSteps));
            AddDialog(new ChoicePrompt($"{nameof(ReturnSelectedValueDialog)}.valueSelection"));

            InitialDialogId = $"{nameof(ReturnSelectedValueDialog)}.mainFlow";
        }

        private async Task<DialogTurnResult> SelectValueStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            StepContext = stepContext;

            return await stepContext.PromptAsync($"{nameof(ReturnSelectedValueDialog)}.cardSelection",
                new PromptOptions
                {
                    Prompt = MessageFactory.Text("Please select a card"),
                    Choices = ChoiceFactory.ToChoices(new string[] { "Selection 1", "Selection 2", "Selection 3" })
                }, cancellationToken);
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            StepContext = stepContext;
            string selectedValue = ((FoundChoice)stepContext.Result).Value;

            //https://techcommunity.microsoft.com/t5/teams-developer/skill-dialog-enddialog-does-not-work/m-p/1476612
            await stepContext.Context.SendActivityAsync(new Activity()
            {
                Type = ActivityTypes.EndOfConversation,
                Code = EndOfConversationCodes.CompletedSuccessfully,
                Value = selectedValue
            });

            return await stepContext.EndDialogAsync();
        }
    }
}
