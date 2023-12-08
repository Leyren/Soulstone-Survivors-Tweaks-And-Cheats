using SoulstoneCheats.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Modifications
{
    public static class RunicPowerModification
    {
        public static void ModifyRunicPower(ref int value)
        {
            value = (int)(value * PluginConfig.RunicPowerMultiplier);
        }
    }
}
