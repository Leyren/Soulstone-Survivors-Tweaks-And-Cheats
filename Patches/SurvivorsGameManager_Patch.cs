using HarmonyLib;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Modifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace SoulstoneCheats.Patches
{
    /// <summary>
    /// SurvivorsGameManager is one of the main manager classes during a game - good to hook into for anything to apply during a match
    /// </summary>
    [HarmonyPatch(typeof(SurvivorsGameManager))]
    internal class SurvivorsGameManager_Patch
    {

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SurvivorsGameManager.Awake))]
        static void Awake_Postfix(SurvivorsGameManager __instance)
        {
           ObjectiveModification.ModifyEnemiesToEliminatePerBoss(__instance);
           MapObstacleModification.RemoveMapObstacles();
        }


        [HarmonyPrefix]
        [HarmonyPatch(nameof(SurvivorsGameManager.Update))]
        static void Update_Prefix(SurvivorsGameManager __instance)
        {
            //Plugin.Log.LogInfo("Alive Units: " + __instance._allEntities.Count);
            Plugin.Log.LogInfo("Invulnerable Time: " + __instance.PlayerEntity?._health?.InvulnerabilityTime);
            PlayerInventoryModification.HandleInventory(__instance.PlayerEntities);
        }

    }

}
