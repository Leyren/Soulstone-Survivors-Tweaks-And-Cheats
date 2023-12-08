using SoulstoneCheats.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Modifications
{
    public static class CurseModification
    {

        /// <summary>
        /// Modifies Curse bonuses, like soulstone, prestige gain etc.
        /// This is a global change and should be applied only once during the game.
        /// </summary>
        public static void ModifyCurseBonuses()
        {
            float multiplier = PluginConfig.CurseBonusMultiplier;
            foreach (var affix in Global.AffixCollection.Affixes)
            {
                foreach (var bonus in affix.Bonuses)
                {
                    bonus.Quantity *= multiplier;
                    Plugin.Log.LogInfo($"Modify Curse Bonus {bonus.Type} of {affix.name} by {multiplier}. New value: {bonus.Quantity}");
                }
            }
        }

        /// <summary>
        /// Modify the strength of buffs the enemies obtain from Curse Level
        /// This is a global change and should be applied only once during the game.
        /// </summary>
        public static void ModifyCurseLevelStrength()
        {
            float multiplier = PluginConfig.CurseLevelStrengthMultiplier;
            Global.AffixCollection.StatsPerCurseLevel.Multiply(multiplier);
            Global.AffixCollection.StatsPerCurseLevelBoss.Multiply(multiplier);
        }
    }
}
