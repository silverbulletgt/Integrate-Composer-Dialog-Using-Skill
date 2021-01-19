using Integrate_Composer_Dialog_Using_Skill_Composer_Generated.Dialogs;
using Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.DialogExtensions;
using Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.State;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.Bots
{
    public class ReturnSelectedValueBot : ActivityHandler
    {
        protected readonly ReturnSelectedValueDialog _dialog;
        protected readonly StateService _stateService;

        public ReturnSelectedValueBot(StateService stateService)
        {
            _dialog = new ReturnSelectedValueDialog();
            _stateService = stateService;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await _dialog.Run(turnContext, _stateService.DialogStateAccessor, cancellationToken);
        }

        protected override Task OnEndOfConversationActivityAsync(ITurnContext<IEndOfConversationActivity> turnContext, CancellationToken cancellationToken)
        {
            return _dialog.RunAsync(turnContext, _stateService.DialogStateAccessor, cancellationToken);
        }
    }
}
