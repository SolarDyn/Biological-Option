# Biological Option

> Bugfixes & Optimizations

[![Release](https://img.shields.io/github/v/release/Solar-Dynamics-Nuclear-Option/Biological-Option?style=flat)](https://github.com/Solar-Dynamics-Nuclear-Option/Biological-Option/releases)
![Game Version](https://img.shields.io/badge/Nuclear_Option-v0.34.2-green?style=flat)
![BepInEx Version](https://img.shields.io/badge/BepInEx-v5.4.23.4-green?style=flat)

**Biological Option** is built for squashing bugs, optimising performance, and making minor improvements behind the
scenes. To any screenshot or video clip, the game should *seem* identical to vanilla while running this.

![Preview](https://github.com/Solar-Dynamics-Nuclear-Option/Assets/blob/main/background/cricket.png)

## Requirements

* Nuclear Option
* BepInEx 5.x

## Features

* `UnityEngine`
  * `+ ApplicationManager`
    * Reduces background resource usage by limiting framerate when unfocused.
* `HUDFunctions`
  * `PinToScreenEdge`
    * Patched mirrored projections of targets behind the screen plane.
* `WeaponManager`
  * `SalvoFire`
    * Patched laser-guided rockets being salvo-fired at unlased targets.

## Installation

### Automatic

1. Install [NOMM](https://github.com/Combat787/NOMM).
2. Use NOMM to install all the mods you want.

### Manual

1. Install [BepInEx](https://github.com/BepInEx/BepInEx).
2. Download the latest release from
   the [Releases](https://github.com/Solar-Dynamics-Nuclear-Option/Template-Project/releases) page.
1. For normal use, it is recommended to use the standard `<name>-<version>.dll` build.
2. For debugging, it is recommended to use the `<name>-<version>-Debug.dll` build.
3. Put the DLL in your plugins folder:

```text
NuclearOption/
└── BepInEx/
    └── plugins/
        └── Template Project/
            └── ProjectName.dll
```

## Compatibility

This project modifies the following game systems:

* `HUDFunctions`

Mods that patch the same methods may conflict.

Known compatible mods:

* None

Known incompatible mods:

* None

## Known Issues

* None

If you encounter a bug that is not listed here, please open an issue.

## Bug Reports

Bug reports should be submitted through
the [GitHub Issues](https://github.com/Solar-Dynamics-Nuclear-Option/Template-Project/issues) page.

When reporting a problem, include as much of the following relevant information as possible:

* Versions
    * Mod Version
    * Nuclear Option Version
    * BepInEx Version
* Logs
    * Nuclear Option Log
    * BepInEx Log
* Steps to reproduce the problem.
* Other installed mods that may be relevant.

Standard Nuclear Option Log Path:

```text
%HOMEPATH%\AppData\LocalLow\Shockfront\NuclearOption\Player.log
```

Standard BepInEx Log Path:

```text
%PROGRAMFILES(X86)%\Steam\steamapps\common\Nuclear Option\BepInEx\LogOutput.log
```

## Credits

| Resource       | Author             |
|----------------|--------------------|
| Nuclear Option | Shockfront Studios |
| MonoMod        | 0x0ade             |
| HarmonyX       | BepInEx            |
| BepInEx        | BepInEx            |

## Disclaimer

This project is an unofficial modification for *Nuclear Option* and is not affiliated with or endorsed by Shockfront
Studios.
