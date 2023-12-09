using HarmonyLib;
using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    /// <summary>
    /// Modify gained soulstones, materials, gained exp, prestige, etc.
    /// </summary>
    public static class LootModification
    {

        public static void ModifyItemAmount(ItemProjectile item)
        {
            item.Amount = (int)(item.Amount * PluginConfig.ItemDropAmountMultiplier);
        }

        public static void ModifyExperienceAmount(CollectableExperience exp)
        {
            exp.ExperienceAmount = (int)(exp.ExperienceAmount * PluginConfig.Player.ExperienceMultiplier);
        }

        public static void ModifyHealthAmount(HealthProjectile health)
        {
            health.HealthAmount *= PluginConfig.HealthPickupAmountMultiplier;
        }

        public static void ModifyMinorSoulstoneAmount(MinorSoulstoneProjectile soulstones)
        {
            soulstones.CurrencyAmount *= PluginConfig.MinorSoulstoneMultiplier;
        }

        public static void ModifyBigSoulstoneAmount(SoulstoneItem soulstone)
        {
            SoulstonePluginUtils.Scale(soulstone.SoulstoneValue, PluginConfig.BossSoulstoneMultiplier);
        }
    }
}
