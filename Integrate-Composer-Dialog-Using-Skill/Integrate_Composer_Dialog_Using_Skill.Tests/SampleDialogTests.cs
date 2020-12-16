﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Integrate_Composer_Dialog_Using_Skill.Tests.Utterances;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Integrate_Composer_Dialog_Using_Skill.Tests
{
    [TestClass]
    public class SampleDialogTests : SkillTestBase
    {
        [TestMethod]
        public async Task Test_Sample_Dialog()
        {
            await GetTestFlow()
                .Send(SampleDialogUtterances.Trigger)
                .AssertReplyOneOf(GetTemplates("FirstPromptText"))
                .Send(SampleDialogUtterances.Trigger)
                .AssertReplyOneOf(GetTemplates("NamePromptText"))
                .Send(SampleDialogUtterances.NamePromptResponse)
                .AssertReplyOneOf(GetTemplates("HaveNameMessageText", new { Name = SampleDialogUtterances.NamePromptResponse }))
                .StartTestAsync();
        }
    }
}
