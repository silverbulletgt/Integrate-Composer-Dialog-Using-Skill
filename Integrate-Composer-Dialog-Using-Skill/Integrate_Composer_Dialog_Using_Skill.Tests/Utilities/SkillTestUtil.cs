// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Integrate_Composer_Dialog_Using_Skill.Tests.Mocks;
using Integrate_Composer_Dialog_Using_Skill.Tests.Utterances;
using Luis;
using Microsoft.Bot.Builder;
using System.Collections.Generic;

namespace Integrate_Composer_Dialog_Using_Skill.Tests.Utilities
{
    public class SkillTestUtil
    {
        private static Dictionary<string, IRecognizerConvert> _utterances = new Dictionary<string, IRecognizerConvert>
        {
            { SampleDialogUtterances.Trigger, CreateIntent(SampleDialogUtterances.Trigger, Integrate_Composer_Dialog_Using_SkillLuis.Intent.Sample) },
        };

        public static MockLuisRecognizer CreateRecognizer()
        {
            var recognizer = new MockLuisRecognizer(defaultIntent: CreateIntent(string.Empty, Integrate_Composer_Dialog_Using_SkillLuis.Intent.None));
            recognizer.RegisterUtterances(_utterances);
            return recognizer;
        }

        public static Integrate_Composer_Dialog_Using_SkillLuis CreateIntent(string userInput, Integrate_Composer_Dialog_Using_SkillLuis.Intent intent)
        {
            var result = new Integrate_Composer_Dialog_Using_SkillLuis
            {
                Text = userInput,
                Intents = new Dictionary<Integrate_Composer_Dialog_Using_SkillLuis.Intent, IntentScore>()
            };

            result.Intents.Add(intent, new IntentScore() { Score = 0.9 });

            result.Entities = new Integrate_Composer_Dialog_Using_SkillLuis._Entities
            {
                _instance = new Integrate_Composer_Dialog_Using_SkillLuis._Entities._Instance()
            };

            return result;
        }
    }
}
