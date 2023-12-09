using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneTweaks.Modifications
{
    public static class SpecialTaskModification
    {

        public static void ModifySpecialPortal(SurvivorsGameManager __instance)
        {
            if (PluginConfig.AutoUnlockSpecialPortals && __instance.HomePortalObject.active)
            {
                GameObject.FindAnyObjectByType<SecretRewardOpenPortal>()?.PortalObject?.SetActive(true);
            }
        }
    }
}
