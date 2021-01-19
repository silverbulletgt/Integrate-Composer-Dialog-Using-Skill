using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.DialogExtensions
{
    public static class DialogExtensions
    {
        public static async Task Run(this Dialog dialog, ITurnContext turnContext, IStatePropertyAccessor<DialogState> accessor, CancellationToken cancellationToken)
        {
            var dialogSet = new DialogSet(accessor);
            dialogSet.Add(dialog);

            var dialogContext = await dialogSet.CreateContextAsync(turnContext, cancellationToken);
            var results = await dialogContext.ContinueDialogAsync(cancellationToken);
            if (results.Status == DialogTurnStatus.Empty)
            {
                await dialogContext.BeginDialogAsync(dialog.Id, null, cancellationToken);
            }
            else if (results.Status == DialogTurnStatus.Complete)
            {
                await EndConversation(turnContext, cancellationToken);
            }
        }

        private static async Task EndConversation(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var endOfConversation = Activity.CreateEndOfConversationActivity();
            endOfConversation.Code = EndOfConversationCodes.CompletedSuccessfully;
            await turnContext.SendActivityAsync(endOfConversation, cancellationToken);
        }
    }
}
