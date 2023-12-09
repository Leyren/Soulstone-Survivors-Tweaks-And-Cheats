using SoulstoneTweaks.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SoulstoneTweaks.Modifications
{
    /// <summary>
    /// Unlocks zoom during a game
    /// </summary>
    public static class ZoomModification
    {
        public static void EnableZoom()
        {
            if (!PluginConfig.UnlockZoom) return;
            // Fog needs to be disabled (or distance modified) since otherwise you can't see anything when zooming out.
            RenderSettings.fog = false;
        }

        public static void UpdateZoom(PlayerCameraController cameraController)
        {
            if (!PluginConfig.UnlockZoom) return;
            cameraController._forcedZoomFactor = Math.Clamp(cameraController._forcedZoomFactor + Input.mouseScrollDelta.y * 0.5f, 0.3f, 5f);
        }

        public static void DisableZoom()
        {
            if (!PluginConfig.UnlockZoom) return;
            // Re-enable fog again at the end, e.g. when switching to main menu
            RenderSettings.fog = true;
        }
    }
}
