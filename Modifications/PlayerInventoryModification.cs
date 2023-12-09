using Il2CppSystem.Collections.Generic;
using SoulstoneTweaks.Core.Config;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoulstoneTweaks.Core.Config.PluginConfig;
using static SoulstoneTweaks.Core.Config.PluginConfig.Player;

namespace SoulstoneTweaks.Modifications
{
    public static class PlayerInventoryModification
    {
        private static bool initialized = false;

        // The inventory data is loaded per match, and it is loaded after the match starts
        // So it needs to be handled in a delayed manner, and make sure to cover unloading as well (when ending match and starting a new one)
        public static void HandleInventory(List<Entity> players)
        {
            if (players == null || players.Count == 0 || players.ToArray().Any(p => p._inventory?.InventoryData == null))
            {
                initialized = false;
                return;
            }
            if (!initialized)
            {
                InitializeInventory(players);
            } else
            {
                UpdateInventory(players);
            }
        }

        private static void InitializeInventory(List<Entity> players)
        {
            foreach (var player in players)
            {
                player._inventory.InventoryData.Rerolls += PluginConfig.Player.Inventory.AdditionalRerolls;
                player._inventory.InventoryData.Banishes += PluginConfig.Player.Inventory.AdditionalBanishes;
                player._inventory.InventoryData.Locks += PluginConfig.Player.Inventory.AdditionalLocks;
                player._inventory.InventoryData.DeathGuards += PluginConfig.Player.Inventory.AdditionalDeathGuards;
            }
            initialized = true;
        }

        private static void UpdateInventory(List<Entity> players)
        {
            foreach (var player in players)
            {
                // Alternative: Set this while hooking into LevelUpPanelManager, since that is the only place where they are being used, but 
                if (PluginConfig.Player.Inventory.InfiniteRerolls)
                {
                    player._inventory.InventoryData.Rerolls = 1000;
                }
                if (PluginConfig.Player.Inventory.InfiniteBanishes)
                {
                    player._inventory.InventoryData.Banishes = 1000;
                }
                if (PluginConfig.Player.Inventory.InfiniteLocks)
                {
                    player._inventory.InventoryData.Locks = 1000;
                }
            }
        }

    }
}
