using BepInEx.Configuration;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Core.Config
{
    public static class PluginConfig
    {

        // Multiplicative factor to apply to all soulstone costs of skill tree elements
        // If set to 0, everything is free.
        public static float SkillTreeCostMultiplier { get; internal set; }

        public static float CurseBonusMultiplier { get; internal set; }
        public static float CurseLevelStrengthMultiplier { get; internal set; }

        public static float TimeModifier { get; internal set; }

        // Loot Chance multiplier (e.g. 2 doubles the chance)
        public static float LootChanceMultiplier { get; internal set; }

        // SoulstoneMultiplier multiplier
        public static float MinorSoulstoneMultiplier { get; internal set; }

        // SoulstoneMultiplier multiplier
        public static float BossSoulstoneMultiplier { get; internal set; }

        // Modifies the amount of health you obtain from health pickups (the greenish crystal things)
        // Can also be negative to damage you on pickup
        public static float HealthPickupAmountMultiplier { get; internal set; }

        // Modifies the amount of health you obtain from health pickups (the greenish crystal things)
        // Can also be negative to damage you on pickup
        public static float ItemDropAmountMultiplier { get; internal set; }

        public static float BossHealthMultiplier { get; internal set; }
        public static float EliteHealthMultiplier { get; internal set; }
        public static float SmallEnemyHealthMultiplier { get; internal set; }
        public static float EnemyObjectiveMultiplier { get; internal set; }
        public static bool DisableEnemyAI { get; internal set; }
        public static bool RemoveMapObstacles { get; internal set; }
        public static bool UnlockZoom { get; internal set; }
        public static bool AutoUnlockSpecialPortals { get; internal set; }
        public static float ExtraMineralsSpawnDelay { get; internal set; }
        public static float WeaponStrengthMultiplier { get; internal set; }
        public static float WeaponUnlockCostMultiplier { get; internal set; }
        public static float CharacterStatsMultiplier { get; internal set; }
        public static float CharacterUnlockCostMultiplier { get; internal set; }
        public static float RunicPowerMultiplier { get; internal set; }

        public static class Player
        {
            public static bool Invulnerable { get; internal set; }

            // Experience multiplier for the in-match level
            public static float ExperienceMultiplier { get; internal set; }
            public static float PrestigeMultiplier { get; internal set; }

            public static class BaseStats
            {
                public static float MaxHealthModifier { get; internal set; }
                public static float CritChanceModifier { get; internal set; }
                public static float CritDamageModifier { get; internal set; }
                public static float DamageModifier { get; internal set; }
                public static float HealingModifier { get; internal set; }
                public static float AttackSpeedModifier { get; internal set; }
                public static float CollectRangeModifier { get; internal set; }
                public static float DamageReductionModifier { get; internal set; }
                public static int DashCount { get; internal set; }
                public static float MovementSpeedModifier { get; internal set; }
                public static float AreaModifier { get; internal set; }
                public static float ArmorModifier { get; internal set; }
                public static float BaseSkillCooldowns { get; internal set; }
                public static float BlockChance { get; internal set; }
                public static float ExtraCastModifier { get; internal set; }
            }
            public static class MultiplicativeStats
            {
                public static float MaxHealthModifier { get; internal set; }
                public static float CritChanceModifier { get; internal set; }
                public static float CritDamageModifier { get; internal set; }
                public static float DamageModifier { get; internal set; }
                public static float HealingModifier { get; internal set; }
                public static float AttackSpeedModifier { get; internal set; }
                public static float CollectRangeModifier { get; internal set; }
                public static float DamageReductionModifier { get; internal set; }
                public static float MovementSpeedModifier { get; internal set; }
                public static float AreaModifier { get; internal set; }
                public static float ArmorModifier { get; internal set; }
                public static float BaseSkillCooldowns { get; internal set; }
                public static float BlockChance { get; internal set; }
                public static float ExtraCastModifier { get; internal set; }
            }

            public static class Inventory
            {
                public static bool InfiniteRerolls { get; internal set; }
                public static int AdditionalRerolls { get; internal set; }
                public static bool InfiniteBanishes { get; internal set; }
                public static int AdditionalBanishes { get; internal set; }
                public static bool InfiniteLocks { get; internal set; }
                public static int AdditionalLocks { get; internal set; }
                public static int AdditionalDeathGuards { get; internal set; }
            }
        }
    }

    internal class PluginConfigHandler
    {
        private ConfigFile config;

        public PluginConfigHandler(ConfigFile config)
        {
            this.config = config;
            InitializeConfig();
        }

        public void InitializeConfig()
        {
            Plugin.Log.LogInfo("Initializing Config at " + config.ConfigFilePath);

            string section = "General";

            Entry(section, nameof(PluginConfig.DisableEnemyAI), false, v => PluginConfig.DisableEnemyAI = v);
            Entry(section, nameof(PluginConfig.RemoveMapObstacles), false, v => PluginConfig.RemoveMapObstacles = v);
            Entry(section, nameof(PluginConfig.SkillTreeCostMultiplier), 1.0f, v => PluginConfig.SkillTreeCostMultiplier = v);
            Entry(section, nameof(PluginConfig.CurseBonusMultiplier), 1.0f, v => PluginConfig.CurseBonusMultiplier = v);
            Entry(section, nameof(PluginConfig.CurseLevelStrengthMultiplier), 1.0f, v => PluginConfig.CurseLevelStrengthMultiplier = v);
            Entry(section, nameof(PluginConfig.TimeModifier), 1.0f, v => PluginConfig.TimeModifier = v);
            Entry(section, nameof(PluginConfig.MinorSoulstoneMultiplier), 1.0f, v => PluginConfig.MinorSoulstoneMultiplier = v);
            Entry(section, nameof(PluginConfig.BossSoulstoneMultiplier), 1.0f, v => PluginConfig.BossSoulstoneMultiplier = v);
            Entry(section, nameof(PluginConfig.HealthPickupAmountMultiplier), 1.0f, v => PluginConfig.HealthPickupAmountMultiplier = v);
            Entry(section, nameof(PluginConfig.ItemDropAmountMultiplier), 1.0f, v => PluginConfig.ItemDropAmountMultiplier = v);
            Entry(section, nameof(PluginConfig.BossHealthMultiplier), 1.0f, v => PluginConfig.BossHealthMultiplier = v);
            Entry(section, nameof(PluginConfig.EliteHealthMultiplier), 1.0f, v => PluginConfig.EliteHealthMultiplier = v);
            Entry(section, nameof(PluginConfig.SmallEnemyHealthMultiplier), 1.0f, v => PluginConfig.SmallEnemyHealthMultiplier = v);
            Entry(section, nameof(PluginConfig.EnemyObjectiveMultiplier), 1.0f, v => PluginConfig.EnemyObjectiveMultiplier = v);
            Entry(section, nameof(PluginConfig.ExtraMineralsSpawnDelay), -1.0f, v => PluginConfig.ExtraMineralsSpawnDelay = v);
            Entry(section, nameof(PluginConfig.UnlockZoom), false, v => PluginConfig.UnlockZoom = v); 
            Entry(section, nameof(PluginConfig.AutoUnlockSpecialPortals), false, v => PluginConfig.AutoUnlockSpecialPortals = v); 
            Entry(section, nameof(PluginConfig.WeaponStrengthMultiplier), 1.0f, v => PluginConfig.WeaponStrengthMultiplier = v);
            Entry(section, nameof(PluginConfig.WeaponUnlockCostMultiplier), 1.0f, v => PluginConfig.WeaponUnlockCostMultiplier = v);
            Entry(section, nameof(PluginConfig.CharacterStatsMultiplier), 1.0f, v => PluginConfig.CharacterStatsMultiplier = v);
            Entry(section, nameof(PluginConfig.CharacterUnlockCostMultiplier), 1.0f, v => PluginConfig.CharacterUnlockCostMultiplier = v);
            Entry(section, nameof(PluginConfig.RunicPowerMultiplier), 1.0f, v => PluginConfig.RunicPowerMultiplier = v);

            section = "Player";
            Entry(section, nameof(PluginConfig.Player.Invulnerable), false, v => PluginConfig.Player.Invulnerable = v);
            Entry(section, nameof(PluginConfig.Player.ExperienceMultiplier), 1.0f, v => PluginConfig.Player.ExperienceMultiplier = v);
            Entry(section, nameof(PluginConfig.Player.PrestigeMultiplier), 1.0f, v => PluginConfig.Player.PrestigeMultiplier = v);

            section = "Player.BaseStats";
            Entry(section, nameof(PluginConfig.Player.BaseStats.DashCount), 0, v => PluginConfig.Player.BaseStats.DashCount = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.MaxHealthModifier), 0f, v => PluginConfig.Player.BaseStats.MaxHealthModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.CritChanceModifier), 0f, v => PluginConfig.Player.BaseStats.CritChanceModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.CritDamageModifier), 0f, v => PluginConfig.Player.BaseStats.CritDamageModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.DamageModifier), 0f, v => PluginConfig.Player.BaseStats.DamageModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.HealingModifier), 0f, v => PluginConfig.Player.BaseStats.HealingModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.AttackSpeedModifier), 0f, v => PluginConfig.Player.BaseStats.AttackSpeedModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.CollectRangeModifier), 0f, v => PluginConfig.Player.BaseStats.CollectRangeModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.DamageReductionModifier), 0f, v => PluginConfig.Player.BaseStats.DamageReductionModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.MovementSpeedModifier), 0f, v => PluginConfig.Player.BaseStats.MovementSpeedModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.AreaModifier), 0f, v => PluginConfig.Player.BaseStats.AreaModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.ArmorModifier), 0f, v => PluginConfig.Player.BaseStats.ArmorModifier = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.BaseSkillCooldowns), 0f, v => PluginConfig.Player.BaseStats.BaseSkillCooldowns = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.BlockChance), 0f, v => PluginConfig.Player.BaseStats.BlockChance = v);
            Entry(section, nameof(PluginConfig.Player.BaseStats.ExtraCastModifier), 0f, v => PluginConfig.Player.BaseStats.ExtraCastModifier = v);

            section = "Player.MultiplicativeStats";
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.MaxHealthModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.MaxHealthModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.CritChanceModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.CritChanceModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.CritDamageModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.CritDamageModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.DamageModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.DamageModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.HealingModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.HealingModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.AttackSpeedModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.AttackSpeedModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.CollectRangeModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.CollectRangeModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.DamageReductionModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.DamageReductionModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.MovementSpeedModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.MovementSpeedModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.AreaModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.AreaModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.ArmorModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.ArmorModifier = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.BaseSkillCooldowns), 0f, v => PluginConfig.Player.MultiplicativeStats.BaseSkillCooldowns = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.BlockChance), 0f, v => PluginConfig.Player.MultiplicativeStats.BlockChance = v);
            Entry(section, nameof(PluginConfig.Player.MultiplicativeStats.ExtraCastModifier), 0f, v => PluginConfig.Player.MultiplicativeStats.ExtraCastModifier = v);

            section = "Player.Inventory";
            Entry(section, nameof(PluginConfig.Player.Inventory.AdditionalRerolls), 1, v => PluginConfig.Player.Inventory.AdditionalRerolls = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.InfiniteRerolls), false, v => PluginConfig.Player.Inventory.InfiniteRerolls = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.AdditionalLocks), 1, v => PluginConfig.Player.Inventory.AdditionalLocks = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.InfiniteLocks), false, v => PluginConfig.Player.Inventory.InfiniteLocks = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.AdditionalBanishes), 1, v => PluginConfig.Player.Inventory.AdditionalBanishes = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.InfiniteBanishes), false, v => PluginConfig.Player.Inventory.InfiniteBanishes = v);
            Entry(section, nameof(PluginConfig.Player.Inventory.AdditionalDeathGuards), 1, v => PluginConfig.Player.Inventory.AdditionalDeathGuards = v);
        }

        public void Entry<T>(string section, string name, T defaultValue, Action<T> consumer)
        {
            name = FormatName(name);
            var entry = config.Bind(section, name, defaultValue);
            Plugin.Log.LogInfo($"Read Config entry {name} = {entry.Value}");
            consumer.Invoke(entry.Value);
            entry.SettingChanged += (_, a) => consumer.Invoke((T) ((SettingChangedEventArgs)a).ChangedSetting.BoxedValue);
        }

        // Format a camel-case string to an underscore string, e.g. FooBarBaz to Foo_Bar_Baz
        public static string FormatName(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
        }
    }
}
