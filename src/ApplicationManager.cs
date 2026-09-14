// Biological-Option - ApplicationManager.cs
// Solar Dynamics 2026

using System;
using NuclearOption.SavedMission.Outcomes;
using UnityEngine;

namespace vet.solar.biological;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager? AppManager { get; private set; }

    public bool IsFocused { get; private set; }

    public int previousTargetFrameRate { get; private set; }

    public int unfocusedTargetFrameRate { get; private set; }

    public void Awake()
    {
        if (AppManager && AppManager != this)
        {
            Plugin.Log.LogError("ApplicationManager already exists.");
            Destroy(gameObject);
            return;
        }

        AppManager = this;

        DontDestroyOnLoad(gameObject);

        unfocusedTargetFrameRate = 30;

        Plugin.Log.LogDebug("ApplicationManager initialized.");
    }

    public void OnDestroy()
    {
        if (AppManager != this) return;

        Plugin.Log.LogDebug("ApplicationManager destroyed.");
        AppManager = null;
    }

    public void OnApplicationFocus(bool hasFocus)
    {
        IsFocused = hasFocus;
        if (hasFocus)
        {
            Application.targetFrameRate = previousTargetFrameRate;
            Plugin.Log.LogDebug($"Game focused, target framerate set to: {previousTargetFrameRate} Hz.");
        }
        else
        {
            previousTargetFrameRate = Application.targetFrameRate;
            Application.targetFrameRate = unfocusedTargetFrameRate;
            Plugin.Log.LogDebug($"Game unfocused, target framerate set to: {unfocusedTargetFrameRate} Hz.");
        }
    }

}