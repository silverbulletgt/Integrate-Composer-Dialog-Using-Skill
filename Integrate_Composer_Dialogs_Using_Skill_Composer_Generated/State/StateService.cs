using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.State
{
    public class StateService
    {
        public ConversationState ConversationState { get; }
        public static string DialogStateId { get; } = $"{nameof(StateService)}.dialogState";

        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; set; }

        public StateService(ConversationState conversationState)
        {
            ConversationState = conversationState;
            InitializeAccessors();
        }

        private void InitializeAccessors()
        {
            DialogStateAccessor = ConversationState.CreateProperty<DialogState>(DialogStateId);
        }
    }
}
