using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulstoneTweaks.Modifications
{
    public static class AIModification
    {

        public static void RemoveEnemyAI(Entity entity)
        {
            if (!PluginConfig.DisableEnemyAI) return;

            // Note: TryGetComponent is not available due to assembly stripping
            var comp = entity.GetComponent<BasicAIComponent>();
            if (comp)
            {
                UnityEngine.GameObject.Destroy(comp);
            }
        }
    }
}
