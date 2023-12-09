using HarmonyLib;
using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Patches
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
