using Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.Bots;
using Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.State;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialogs_Using_Skill_Composer_Generated.Controllers
{
    [Route("api/returnselectedvalue/messages")]
    [ApiController]
    public class ReturnSelectedValueController : Controller
    {
        private readonly IBotFrameworkHttpAdapter _adapter;
        private readonly IBot _bot;

        public ReturnSelectedValueController(IBotFrameworkHttpAdapter httpAdapter, StateService stateService)
        {
            _adapter = httpAdapter;
            _bot = new ReturnSelectedValueBot(stateService);
        }

        [HttpPost]
        [HttpGet]
        public async Task PostAsync()
        {
            await _adapter.ProcessAsync(Request, Response, _bot);
        }
    }
}
