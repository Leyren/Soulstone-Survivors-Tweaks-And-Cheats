using BepInEx.Unity.IL2CPP.Utils.Collections;
using SoulstoneCheats.Core.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneCheats.Modifications
{
    public static class MineralModification
    {
        private static Coroutine coroutine;

        public static void SpawnExtraMinerals(SurvivorsGameManager __instance)
        {
            if (PluginConfig.ExtraMineralsSpawnDelay < 0) return; 
            coroutine = __instance.StartCoroutine(SpawnMineral(PluginConfig.ExtraMineralsSpawnDelay, __instance).WrapToIl2Cpp());
        }

        public static void StopSpawningExtraMinerals(SurvivorsGameManager __instance)
        {
            if (coroutine != null) {
                __instance.StopCoroutine(coroutine);
            }
        }

        private static IEnumerator SpawnMineral(float waitTime, SurvivorsGameManager __instance)
        {
            yield return new WaitForSeconds(5.0f);
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                __instance.SpawnMineral(false);
            }
        }
    }
}
