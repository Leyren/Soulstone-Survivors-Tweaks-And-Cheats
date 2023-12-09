using ECM2.Characters;
using HarmonyLib;
using Il2CppSystem.Reflection;
using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Modifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoulstoneTweaks.Core.Config.PluginConfig;

namespace SoulstoneTweaks.Patches
{
    [HarmonyPatch(typeof(Entity))]
    internal class Entity_Patch
    {

        static Dictionary<IntPtr, float> healths = new();

        // There is also EnemyPrefabsUtil which contains the prefabs for all enemies, including health, prestige etc. But somehow changing that has no effect.
        // Maybe it's cloned, ignored, who knows
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Entity.Setup))]
        static void Entity_StartPrefix(Entity __instance, MethodBase __originalMethod)
        {
            if (!__instance.Health.HasReference) return;
            if (__instance.tag == "Player")
            {
                PlayerStatsModification.ModifyPlayerStats(__instance);
                return;
            }
            var healthType = __instance._health.GameStatsHealthType;
            float multiplier = 1f;

            AIModification.RemoveEnemyAI(__instance);

            switch (healthType)
            {
                case GameStatsHealthType.None: // Player or other non-enemy objects
                    break;
                case GameStatsHealthType.Enemy:
                    multiplier = PluginConfig.SmallEnemyHealthMultiplier;
                    break;
                case GameStatsHealthType.Elite:
                    multiplier = PluginConfig.EliteHealthMultiplier;
                    break;
                case GameStatsHealthType.Boss:
                    multiplier = PluginConfig.BossHealthMultiplier;
                    break;
                default:
                    break;
            }
            //Plugin.Log.LogInfo("Modify health by " + multiplier + " for " + __instance.EntityName + " of type " + healthType);
            if (multiplier == 1) return;

            // NOTE: Health scaling is kinda weird.
            // The Max Health is the BASE max health, so e.g. 3200 for bosses. The actual 'CurrentHealth' can even be above that
            // Not clear yet where the scaling comes from (going from 3200 base health to e.g. 19000 actual health) but it works.
            if (!healths.ContainsKey(__instance.Pointer))
            {
                __instance._health.CurrentHealth = (float)(__instance._health.CurrentHealth * multiplier);
                __instance.Stats.Reference.Stats.MaxHealth = (float)(__instance.Stats.Reference.Stats.MaxHealth * multiplier);
                healths.Add(__instance.Pointer, __instance.Stats.Reference.Stats.MaxHealth);
            }
            else if (healths[__instance.Pointer] != __instance.Stats.Reference.Stats.MaxHealth)
            {
                __instance._health.CurrentHealth = (float)(__instance._health.CurrentHealth * multiplier);
                __instance.Stats.Reference.Stats.MaxHealth = (float)(__instance.Stats.Reference.Stats.MaxHealth * multiplier);
                healths[__instance.Pointer] = __instance.Stats.Reference.Stats.MaxHealth;
            }
        }

    }
}
