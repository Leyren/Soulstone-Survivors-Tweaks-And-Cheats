using HarmonyLib;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Patches
{
    [HarmonyPatch(typeof(UIUtil))]
    internal class UIUtils_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(UIUtil.GetTotalRunicPower))]
        static void GetTotalRunicPower_Postfix(ref int __result)
        {
            RunicPowerModification.ModifyRunicPower(ref __result);
        }
    }
}
