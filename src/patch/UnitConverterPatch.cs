// Biological-Option - UnitConverterPatch.cs
// Solar Dynamics 2026

using System;
using HarmonyLib;
using JetBrains.Annotations;

namespace vet.solar.biological.patch;


[HarmonyPatch(typeof(UnitConverter), nameof(UnitConverter.WeightReading))]
public class Patch_UnitConverter_WeightReading
{
    [UsedImplicitly]
    public static bool Prefix(float weight, ref string __result)
    {
        if (PlayerSettings.unitSystem == PlayerSettings.UnitSystem.Metric)
        {
            if (weight >= 899999.0)
            {
                __result = $"{weight * 1E-6f:F2}kt";
                return false;
            }
            if (weight >= 2999.0)
            {
                __result = $"{weight * 1E-3f:F1}t";
                return false;
            }

            __result = $"{weight:F0}kg";
            return false;
        }

        float weight_lb = weight * 2.2046226218f;
        float weight_tn = weight * 1.1023113109E-3f;

        if (weight_tn >= 1E4f)
        {
            __result = $"{weight_tn * 1E-3f:F0}ktn";
            return false;
        }

        if (weight_tn >= 1E3f)
        {
            __result = $"{weight_tn * 1E-3f:F1}ktn";
            return false;
        }

        if (weight_tn >= 1E2f)
        {
            __result = $"{weight_tn:F0}tn";
            return false;
        }

        if (weight_tn >= 1E1f)
        {
            __result = $"{weight_tn:F1}tn";
            return false;
        }

        if (weight_lb >= 1E4f)
        {
            __result = $"{weight_tn:F2}tn";
            return false;
        }

        __result = $"{weight_lb:F0}lb";
        return false;
    }
}


[HarmonyPatch(typeof(UnitConverter), nameof(UnitConverter.YieldReading))]
public class Patch_UnitConverter_YieldReading
{
    [UsedImplicitly]
    public static bool Prefix(float yield, ref string __result)
    {
        if (PlayerSettings.unitSystem == PlayerSettings.UnitSystem.Metric)
        {
            if (yield >= 1E10f)
            {
                __result = $"{yield * 1E-9f:F0}Mt";
                return false;
            }

            if (yield >= 1E8f)
            {
                __result = $"{yield * 1E-6f:F0}kt";
                return false;
            }

            if (yield >= 1E6f)
            {
                __result = $"{yield * 1E-6f:F1}kt";
                return false;
            }
            __result = $"{yield:F0}kg";
            return false;
        }

        float yield_lb = yield * 2.2046226218f;
        float yield_tn = yield * 1.1023113109E-3f;

        if (yield_tn >= 1E10f)
        {
            __result = $"{yield_tn * 1E-9f:F0}Gtn";
            return false;
        }

        if (yield_tn >= 1E9f)
        {
            __result = $"{yield_tn * 1E-9f:F1}Gtn";
            return false;
        }

        if (yield_tn >= 1E7f)
        {
            __result = $"{yield_tn * 1E-6f:F0}Mtn";
            return false;
        }

        if (yield_tn >= 1E6f)
        {
            __result = $"{yield_tn * 1E-6f:F1}Mtn";
            return false;
        }

        if (yield_tn >= 1E4f)
        {
            __result = $"{yield_tn * 1E-3f:F0}ktn";
            return false;
        }

        if (yield_tn >= 1E3f)
        {
            __result = $"{yield_tn * 1E-3f:F1}ktn";
            return false;
        }

        if (yield_tn >= 1E2f)
        {
            __result = $"{yield_tn:F0}tn";
            return false;
        }

        if (yield_tn >= 1E1f)
        {
            __result = $"{yield_tn:F1}tn";
            return false;
        }

        if (yield_lb >= 1E4f)
        {
            __result = $"{yield_tn:F2}tn";
            return false;
        }

        __result = $"{yield_lb:F0}lb";
        return false;
    }
}