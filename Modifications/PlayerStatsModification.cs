using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    public static class PlayerStatsModification
    {
        public static void ModifyPlayerStats(Entity entity)
        {
            var stats = entity.Stats.Reference.Stats;
            stats.MaxHealth += PluginConfig.Player.BaseStats.MaxHealthModifier;
            stats.MovementSpeedModifier += PluginConfig.Player.BaseStats.MovementSpeedModifier;
            stats.AreaModifier += PluginConfig.Player.BaseStats.AreaModifier;
            stats.ArmorModifier += PluginConfig.Player.BaseStats.ArmorModifier;
            stats.AttackSpeed += PluginConfig.Player.BaseStats.AttackSpeedModifier;
            stats.BaseSkillCooldowns += PluginConfig.Player.BaseStats.BaseSkillCooldowns;
            stats.BlockChance += PluginConfig.Player.BaseStats.BlockChance;
            stats.CritChance += PluginConfig.Player.BaseStats.CritChanceModifier;
            stats.CollectRange += PluginConfig.Player.BaseStats.CollectRangeModifier;
            stats.CritPotency += PluginConfig.Player.BaseStats.CritDamageModifier;
            stats.DamageModifier += PluginConfig.Player.BaseStats.DamageModifier;
            stats.DamageReduction += PluginConfig.Player.BaseStats.DamageReductionModifier;
            stats.ExtraCastModifier += PluginConfig.Player.BaseStats.ExtraCastModifier;
            stats.HealingModifier += PluginConfig.Player.BaseStats.HealingModifier;

            stats.DashCount += PluginConfig.Player.BaseStats.DashCount;

            var mulStats = entity.Stats.Reference.MultiplicativeStats;
            mulStats.MaxHealth += PluginConfig.Player.MultiplicativeStats.MaxHealthModifier;
            mulStats.MovementSpeedModifier += PluginConfig.Player.MultiplicativeStats.MovementSpeedModifier;
            mulStats.AreaModifier += PluginConfig.Player.MultiplicativeStats.AreaModifier;
            mulStats.ArmorModifier += PluginConfig.Player.MultiplicativeStats.ArmorModifier;
            mulStats.AttackSpeed += PluginConfig.Player.MultiplicativeStats.AttackSpeedModifier;
            mulStats.BaseSkillCooldowns += PluginConfig.Player.MultiplicativeStats.BaseSkillCooldowns;
            mulStats.BlockChance += PluginConfig.Player.MultiplicativeStats.BlockChance;
            mulStats.CritChance += PluginConfig.Player.MultiplicativeStats.CritChanceModifier;
            mulStats.CollectRange += PluginConfig.Player.MultiplicativeStats.CollectRangeModifier;
            mulStats.CritPotency += PluginConfig.Player.MultiplicativeStats.CritDamageModifier;
            mulStats.DamageModifier += PluginConfig.Player.MultiplicativeStats.DamageModifier;
            mulStats.DamageReduction += PluginConfig.Player.MultiplicativeStats.DamageReductionModifier;
            mulStats.ExtraCastModifier += PluginConfig.Player.MultiplicativeStats.ExtraCastModifier;
            mulStats.HealingModifier += PluginConfig.Player.MultiplicativeStats.HealingModifier;

            if (PluginConfig.Player.Invulnerable)
            {
                entity._health.InvulnerabilityTime = float.MaxValue;
                entity._health.InvulnerabilityTimeWhenSpawned = float.MaxValue;
            }
        }

        public static void X()
        {
            if (PluginConfig.Player.Invulnerable)
            {
                //entity._health.InvulnerabilityTime = float.MaxValue;
            }
        }
    }
}
