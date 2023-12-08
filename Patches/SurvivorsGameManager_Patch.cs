using BepInEx.Unity.IL2CPP.Utils;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using ECM2.Characters;
using HarmonyLib;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Modifications;
using System;
using System.Collections;
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
            ZoomModification.EnableZoom();
            MineralModification.SpawnExtraMinerals(__instance);
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SurvivorsGameManager.OnDestroy))]
        static void OnDestroy_Prefix(SurvivorsGameManager __instance)
        {
            ZoomModification.DisableZoom();
            MineralModification.StopSpawningExtraMinerals(__instance);
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SurvivorsGameManager.Update))]
        static void Update_Prefix(SurvivorsGameManager __instance)
        {
            PlayerInventoryModification.HandleInventory(__instance.PlayerEntities);
        }

    }

}
