// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Integrate_Composer_Dialog_Using_Skill.Models
{
    public class SkillState
    {
        public string Token { get; set; }

        public TimeZoneInfo TimeZone { get; set; }

        public void Clear()
        {
        }
    }
}
