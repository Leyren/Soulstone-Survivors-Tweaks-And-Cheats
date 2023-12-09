using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneTweaks.Modifications
{
    public static class TimeModification
    {

        public static void ModifyTime()
        {
            UnityEngine.Time.timeScale = Time.timeScale == 0 ? 0 : PluginConfig.TimeModifier;
        }

        public static void ResetTime()
        {
            UnityEngine.Time.timeScale = Time.timeScale == 0 ? 0 : 1.0f;
        }
    }
}
