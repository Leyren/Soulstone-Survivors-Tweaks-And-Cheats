using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    public static class CharacterModification
    {
        public static void ModifyCharacterStatsAndCosts()
        {
            float strength = PluginConfig.CharacterStatsMultiplier;
            float cost = PluginConfig.CharacterUnlockCostMultiplier;
            if (strength == 1 && cost == 1) return;

            Plugin.Log.LogInfo($"Modify Characters: Stats x {strength}, Costs x {cost}");
            foreach (var character in Global.CharacterCollection.Characters)
            {
                character.CharacterStats.Multiply(strength);
                SoulstonePluginUtils.Scale(character.CostToUnlock, cost);
            }
        }
    }
}
