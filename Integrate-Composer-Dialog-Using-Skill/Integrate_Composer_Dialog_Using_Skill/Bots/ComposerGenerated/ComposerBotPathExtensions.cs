using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialog_Using_Skill.Bots.ComposerGenerated
{
    /// <summary>
    /// This code is from Microsoft.BotFramework.Composer.Core ComposerBotPathExtensions.cs
    /// This class is generated when using Composer Generate Runtime for bot
    /// </summary>
    public static class ComposerBotPathExtensions
    {
        public static IConfigurationBuilder UseBotPathConverter(this IConfigurationBuilder builder)
        {
            var settings = new Dictionary<string, string>();
            settings["bot"] = "ComposerDialogs";
            builder.AddInMemoryCollection(settings);
            return builder;
        }
    }
}
