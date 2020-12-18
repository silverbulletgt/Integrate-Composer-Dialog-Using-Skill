using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialog_Using_Skill.Controllers
{
    /// <summary>
    /// A controller that handles skill replies to the bot.
    /// This example uses the <see cref="SkillHandler"/> that is registered as a <see cref="ChannelServiceHandler"/> in startup.cs.
    /// From: https://github.com/microsoft/botbuilder-dotnet/blob/main/tests/Microsoft.Bot.Builder.TestBot.Json/Controllers/SkillController.cs
    /// </summary>
    [ApiController]
    [Route("api/skills")]
    public class SkillController : ChannelServiceController
    {
        public SkillController(ChannelServiceHandler handler)
            : base(handler)
        {
        }

        public override Task<IActionResult> ReplyToActivityAsync(string conversationId, string activityId, Activity activity)
        {
            return base.ReplyToActivityAsync(conversationId, activityId, activity);
        }

        public override Task<IActionResult> SendToConversationAsync(string conversationId, Activity activity)
        {
            return base.SendToConversationAsync(conversationId, activity);
        }
    }
}
