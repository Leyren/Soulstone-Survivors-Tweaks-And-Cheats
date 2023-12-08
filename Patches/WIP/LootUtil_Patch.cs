using HarmonyLib;
using SoulstoneCheats.Core;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneCheats.Patches.WIP
{
    // This is called to determine what loot to drop
    // DO NOT USE THIS TO MODIFY EXPERIENCE AND OTHER DROP AMOUNTS
    // BECAUSE IT WILL RESULT IN MORE INGAME ENTITIES
    // (e.g. x100 EXP means that an enemy that normally drops 1 EXP orb now drops 100, on bosses this lags, freezes or crashes the game)
    //[HarmonyPatch(typeof(LootUtil), nameof(LootUtil.CalculateLoot))]
    internal class LootUtil_Patch
    {

        static void Prefix(ref LootComponent loot)
        {
            // Prestige is rewarded immediately on kill, there is no drop for it.
            // Could've also modified it on the entity directly on spawn, but seems more reasonable to do it on kill
            loot.Prestige *= PluginConfig.Player.PrestigeMultiplier;


            /* if (loot.PossibleItems.Count > 0)
             {
                 Plugin.Log.LogInfo("Possible Loot " + loot.PossibleItems.Count);
                 foreach (var item in loot.PossibleItems)
                 {
                     Plugin.Log.LogInfo(item.ItemId + ", " + item.QuantityMin + ", " + item.QuantityMax + ", " + item.Chance);
                 }
                 Plugin.Log.LogInfo("Loot By Tier " + loot.ItemsByTier.Count);
                 foreach (var itembytier in loot.ItemsByTier)
                 {
                     foreach (var item in itembytier.Items)
                     {
                         Plugin.Log.LogInfo("Tier: " + itembytier.Tier + ", " + item.ItemId + ", " + item.QuantityMin + ", " + item.QuantityMax + ", " + item.Chance);
                     }
                 }
             }
            */
        }
    }
}
