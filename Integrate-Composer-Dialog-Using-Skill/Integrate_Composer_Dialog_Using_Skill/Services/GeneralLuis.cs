// <auto-generated>
// Code generated by LUISGen
// Tool github: https://github.com/microsoft/botbuilder-tools
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Luis
{
    public class GeneralLuis : IRecognizerConvert
    {
        public string Text;
        public string AlteredText;
        public enum Intent
        {
            Cancel,
            Confirm,
            Escalate,
            FinishTask,
            GoBack,
            Help,
            Logout,
            None,
            ReadAloud,
            Reject,
            Repeat,
            SelectAny,
            SelectItem,
            SelectNone,
            ShowNext,
            ShowPrevious,
            StartOver,
            Stop
        };
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {
            // Simple entities
            public string[] DirectionalReference;

            // Built-in entities
            public double[] number;
            public double[] ordinal;

            // Instance
            public class _Instance
            {
                public InstanceData[] DirectionalReference;
                public InstanceData[] number;
                public InstanceData[] ordinal;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties { get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<GeneralLuis>(JsonConvert.SerializeObject(result));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}
