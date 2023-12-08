using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HarmonyLib.Tools;
using Il2CppSystem.Runtime.Remoting;
using SoulstoneCheats.Core.Config;
using SoulstoneCheats.Patches;
using SoulstoneCheats.Unity;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace SoulstoneCheats;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{

    internal static new ManualLogSource Log;


    public override void Load()
    {
        Plugin.Log = base.Log;
        Log.LogInfo($"Loading plugin...");

        CurrencyUtil.GetPriceValueByCurrencyPrice(new PlayerProfileCurrencies());

        PluginConfigHandler configHandler = new PluginConfigHandler(Config);

        Log.LogInfo($"Injecting Unity component");
        AddComponent<PluginUnityComponent>();

        Log.LogInfo($"Initializing Harmony Patcher");
        var harmony = new Harmony("leyren.soulstonecheats");
        HarmonyFileLog.Enabled = true;

        Log.LogInfo($"Applying Patches");
        harmony.PatchAll();

        Log.LogInfo($"Plugin Loading Completed");
        // PlayerProfileCurrencies

        // public Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<PlayerProfileCurrencies> CostToUnlock { get; set; }
        //Member of SkillTreeItemSO

    }
}
