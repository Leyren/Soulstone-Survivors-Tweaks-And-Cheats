using SoulstoneCheats.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneCheats.Modifications
{
    public static class ObjectiveModification
    {
        public static void ModifyEnemiesToEliminatePerBoss(SurvivorsGameManager manager)
        {
            float multiplier = PluginConfig.EnemyObjectiveMultiplier;
            if (multiplier == 1) return;

            for (int i = 0; i < manager.EnemiesToEliminatePerBoss.Length; i++)
            {
                manager.EnemiesToEliminatePerBoss[i] = (int)(manager.EnemiesToEliminatePerBoss[i] * multiplier);
            }
            Plugin.Log.LogInfo($"Modified Enemies to Eliminate per Boss. New values: {string.Join(", ", manager.EnemiesToEliminatePerBoss)}");
        }
    }
}
