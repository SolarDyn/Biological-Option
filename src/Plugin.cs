// Biological-Option - Plugin.cs
// Solar Dynamics 2026

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace vet.solar.biological;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public sealed class Plugin : BaseUnityPlugin
{
    public const string PluginGUID = MyPluginInfo.PLUGIN_GUID;
    public const string PluginName = MyPluginInfo.PLUGIN_NAME;
    public const string PluginVersion = MyPluginInfo.PLUGIN_VERSION;

    private Harmony? _harmony;

    internal static ManualLogSource Log { get; private set; }

    // internal static GameObject manager { get; private set; }

    private void Awake()
    {
        Log = Logger;

        Log.LogInfo("Version " + PluginVersion + " loading...");

        _harmony = new Harmony(PluginGUID);
        _harmony.PatchAll();

        // manager = new GameObject("BiologicalManager");
        this.gameObject.AddComponent<ApplicationManager>();
        // DontDestroyOnLoad(manager);

        Log.LogInfo("Loaded.");
    }

    private void OnDestroy()
    {
        Log ??= Logger;

        Log.LogInfo("Unloading...");

        _harmony?.UnpatchSelf();

        Log.LogInfo("Unloaded.");
    }
}