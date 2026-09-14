// Biological-Option - HUDFunctionsPatch.cs
// Solar Dynamics 2026

using HarmonyLib;
using UnityEngine;

namespace vet.solar.biological.patch;

[HarmonyPatch(typeof(HUDFunctions))]
public class HUDFunctionsPatch
{
    [HarmonyPatch(nameof(HUDFunctions.PinToScreenEdge))]
    [HarmonyPrefix]
    public static bool PinToScreenEdge(
        Vector3 coords,
        out Vector3 rayToScreen,
        out float arrowAngle,
        ref bool __result)
    {
        Camera camera = SceneSingleton<CameraStateManager>.i.mainCamera;

        Vector3 screenCenter = new(
            Screen.width * 0.5f,
            Screen.height * 0.5f,
            0f);

        Vector3 screenPos = camera.WorldToScreenPoint(coords);

        bool behind = screenPos.z < 0f;

        rayToScreen = screenPos - screenCenter;
        rayToScreen.z = 0f;

        if (behind)
            rayToScreen = -rayToScreen;

        arrowAngle = Mathf.Atan2(rayToScreen.y, rayToScreen.x);

        bool outside =
            behind ||
            Mathf.Abs(rayToScreen.x) > screenCenter.x ||
            Mathf.Abs(rayToScreen.y) > screenCenter.y;

        if (outside)
        {
            float tan = Mathf.Tan(arrowAngle);

            rayToScreen = rayToScreen.x <= 0f
                ? new Vector3(-screenCenter.x, -screenCenter.x * tan, 0f)
                : new Vector3(screenCenter.x, screenCenter.x * tan, 0f);

            if (rayToScreen.y > screenCenter.y)
            {
                rayToScreen = new Vector3(
                    screenCenter.y / tan,
                    screenCenter.y,
                    0f);
            }
            else if (rayToScreen.y < -screenCenter.y)
            {
                rayToScreen = new Vector3(
                    -screenCenter.y / tan,
                    -screenCenter.y,
                    0f);
            }
        }

        rayToScreen += screenCenter;
        __result = outside;
        return false;
    }
}