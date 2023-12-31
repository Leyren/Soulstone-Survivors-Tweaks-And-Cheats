﻿using HarmonyLib;
using SoulstoneTweaks.Modifications;

namespace SoulstoneTweaks.Patches
{

    [HarmonyPatch]
    internal class SpecialProjectile_Patch
    {

        // Collectible Soulstones
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MinorSoulstoneProjectile), nameof(MinorSoulstoneProjectile.DoOnReachedTarget))]
        static void MinorSoulstoneProjectile_Prefix(MinorSoulstoneProjectile __instance)
        {
            LootModification.ModifyMinorSoulstoneAmount(__instance);
        }

        // Collectible Health drops
        [HarmonyPrefix]
        [HarmonyPatch(typeof(HealthProjectile), nameof(HealthProjectile.DoOnReachedTarget))]
        static void HealthProjectile_Prefix(HealthProjectile __instance)
        {
            LootModification.ModifyHealthAmount(__instance);
        }

        // Collectible Experience crystals
        [HarmonyPrefix]
        [HarmonyPatch(typeof(CollectableExperience), nameof(CollectableExperience.DoOnReachedTarget))]
        static void CollectableExperience_Prefix(CollectableExperience __instance)
        {
            LootModification.ModifyExperienceAmount(__instance);
        }

        // Materials like iron etc.
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemProjectile), nameof(ExperienceProjectile.DoOnReachedTarget))]
        static void ItemProjectile_Prefix(ItemProjectile __instance)
        {
            LootModification.ModifyItemAmount(__instance);
        }

        // SoulstoneItem are the big soulstones dropped by bosses
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SoulstoneItem), nameof(SoulstoneItem.OnCollect))]
        static void Prefix(SoulstoneItem __instance)
        {
            LootModification.ModifyBigSoulstoneAmount(__instance);
        }
    }

}
