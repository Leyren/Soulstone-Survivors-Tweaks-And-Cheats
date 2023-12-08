using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Modifications
{
    public static class SkillTreeCostModification
    {
        /// <summary>
        /// Modifies the costs of all skill tree elements
        /// This is a global change and should be applied only once during the game.
        /// </summary>
        public static void ModifySkillTreeCosts()
        {
            float multiplier = PluginConfig.SkillTreeCostMultiplier;
            //Plugin.Log.LogDebug("Apply multiplier of " + multiplier + " to costs of " + __instance.name);

            if (multiplier == 1) return;

            // Skill trees are grouped into bundles, one for each character and one for global (SkillTreeType=None)
            foreach (var bundle in Global.SkillTreeCollectionBundle.SkillTreeCollectionBundles)
            {
                Plugin.Log.LogInfo($"Modifying {bundle.SkillTreeType} skill tree costs...");
                foreach (var skillTreeItem in bundle.SkillTreeCollectionSO.Items)
                {
                    ModifySkillCosts(skillTreeItem, multiplier);
                }
            }
        }

        private static void ModifySkillCosts(SkillTreeItemSO skillTreeItem, float multiplier)
        {
            Plugin.Log.LogInfo($"\tApply factor {multiplier} to skill tree item {skillTreeItem.name}");
            // Array of costs describes costs for each upgrade level, first element for first upgrade, etc.
            for (int i = 0; i < skillTreeItem.CostToUnlock.Count; i++)
            {
                PlayerProfileCurrencies cost = skillTreeItem.CostToUnlock[i];
                SoulstonePluginUtils.Scale(cost, multiplier);
                Plugin.Log.LogInfo($"\t\tApply factor {multiplier} to level {i + 1} of skill tree item {skillTreeItem.name}. New costs {SoulstonePluginUtils.AsString(cost)}");
            }
        }
    }
}
