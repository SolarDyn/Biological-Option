// Biological-Option - WeaponManagerPatch.cs
// Solar Dynamics 2026

using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using HarmonyLib;
using JetBrains.Annotations;

namespace vet.solar.biological.patch;

[HarmonyPatch(typeof(WeaponManager))]
public static class WeaponManagerPatch
{
    public static async UniTask SalvoFireLaser(WeaponManager manager, List<Unit> targets, float salvoInterval)
    {
        int i = 0;
        WeaponStation salvoStation = manager.currentWeaponStation;
        CancellationToken cancel = manager.destroyCancellationToken;
        while (i < targets.Count)
        {
            Unit target = targets[i];
            if (!manager.aircraft || !manager.aircraft.NetworkHQ)
            {
                salvoStation = null;
                cancel = new CancellationToken();
                return;
            }
            if (target && !target.disabled && manager.aircraft.NetworkHQ.IsTargetLased(target))
                salvoStation.LaunchMount(manager.aircraft, target, new GlobalPosition());
            ++i;
            await UniTask.Delay((int) (salvoInterval * 1000.0));
            if (cancel.IsCancellationRequested)
            {
                salvoStation = null;
                cancel = new CancellationToken();
                return;
            }
        }
        salvoStation.SalvoInProgress = false;
        salvoStation = null;
        cancel = new CancellationToken();
    }

    public static bool IsLaserGuided(WeaponStation station)
    {
        foreach (Weapon weapon in station.Weapons)
        {
            if (weapon == null)
                continue;

            return weapon.info.laserGuided;
        }

        return false;
    }

    [HarmonyPatch(nameof(WeaponManager.SalvoFire))]
    [HarmonyPrefix]
    public static bool SalvoFirePrefix(WeaponManager __instance, List<Unit> targets, float salvoInterval, ref UniTask __result)
    {
        WeaponStation station = __instance.currentWeaponStation;
        if (station == null || !IsLaserGuided(station))
            return true;

        __result = SalvoFireLaser(__instance, targets, salvoInterval);
        return false;
    }
}