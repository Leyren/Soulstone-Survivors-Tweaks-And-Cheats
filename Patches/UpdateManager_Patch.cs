using HarmonyLib;
using SoulstoneTweaks.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneTweaks.Patches
{
    [HarmonyPatch(typeof(UpdateManager))]
    internal class UpdateManager_Patch
    {

        // Hacky workaround because somewhere in the game logic loop it resets the timeScale back to 1.0
        // for whatever reason...
        // Changing it before the update managers update seems to work fine though
        [HarmonyPrefix]
        [HarmonyPatch(nameof(UpdateManager.Update))]
        static void Update_Prefix()
        {
            TimeModification.ModifyTime();
        }
    }
}
