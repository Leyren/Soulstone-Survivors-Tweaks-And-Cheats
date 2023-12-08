using ECM2.Characters;
using HarmonyLib;
using SoulstoneCheats.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Patches
{
    [HarmonyPatch(typeof(PlayerCharacter))]
    internal class PlayerCharacter_Patch
    {

        [HarmonyPrefix]
        [HarmonyPatch(nameof(PlayerCharacter.OnUpdate))]
        static void Update_Prefix(PlayerCharacter __instance)
        {
            ZoomModification.UpdateZoom(__instance.PlayerCameraController);
        }
    }
}
