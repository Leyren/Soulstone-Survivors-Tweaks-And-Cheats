using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppSystem;
using Il2CppSystem.Runtime.Remoting;
using SoulstoneTweaks.Core.Config;
using SoulstoneTweaks.Patches;
using SoulstoneTweaks.Unity;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;

namespace SoulstoneTweaks;

[BepInPlugin(Info.GUID, Info.Name, Info.Version)]
public class Plugin : BasePlugin
{
    public static class Info
    {
        public const string GUID = "SoulstoneTweaks";
        public const string Name = "Soulstone Tweaks";
        public const string Version = "1.0.0";
    }

    internal static new ManualLogSource Log;


    public override void Load()
    {
        Plugin.Log = base.Log;
        Log.LogInfo($"Loading plugin...");

        var customFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "SoulstoneTweaks.cfg"), true);
        PluginConfigHandler configHandler = new(customFile);

        Log.LogInfo($"Injecting Unity component");
        AddComponent<PluginUnityComponent>();

        Log.LogInfo($"Initializing Harmony Patcher");
        var harmony = new Harmony("leyren.soulstonetweaks");
        HarmonyFileLog.Enabled = true;

        Log.LogInfo($"Applying Patches");
        harmony.PatchAll();

        Log.LogInfo($"Plugin Loading Completed");
    }
}
