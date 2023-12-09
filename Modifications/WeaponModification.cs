using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    public static class WeaponModification
    {
        public static void ModifyWeaponStatsAndCosts()
        {
            float strength = PluginConfig.WeaponStrengthMultiplier;
            float cost = PluginConfig.WeaponUnlockCostMultiplier;
            if (strength == 1 && cost == 1) return;

            Plugin.Log.LogInfo($"Modify Weapons: Stats x {strength}, Costs x {cost}");
            foreach (var weaponCollection in Global.WeaponCollection.WeaponsPerCharacter)
            {
                foreach (var weapon in weaponCollection.Definitions)
                {
                    weapon.CharacterStats.Multiply(strength);
                    SoulstonePluginUtils.Scale(weapon.CostToUnlock, cost);
                    foreach (var item in weapon.MaterialsToUnlock.Items)
                    {
                        item.Quantity = (int)Math.Ceiling(item.Quantity * cost);
                    }
                }
            }
        }
    }
}
