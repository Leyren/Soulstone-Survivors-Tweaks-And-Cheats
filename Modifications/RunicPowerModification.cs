using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    public static class RunicPowerModification
    {
        public static void ModifyRunicPower(ref int value)
        {
            value = (int)(value * PluginConfig.RunicPowerMultiplier);
        }
    }
}
