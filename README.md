# Soulstone-Survivors-Tweak-Mod
 A BepInEx mod for the Steam Game 'Soulstone Survivors', providing access to a bunch of tweaks to make the game infinitely harder, or cheatily easy.
 Built for Soulstone Survivors `Early Access 0.11.038a - Windows`.

# Installation

This mod requires BepInEx v6 (Bleeding Edge), due to Soulstone Survivors using IL2CPP which is only supported by BepInEx v6. Developed using [Build #666](https://builds.bepinex.dev/projects/bepinex_be).
Unpack BepInEx into your game folder (usually something like `C:\Program Files (x86)\Steam\steamapps\common\Soulstone Survivors`), and run the game once.

You should now have a `BepInEx/plugins` folder. Drop the `SoulstoneTweaks.dll` in there and you're good to go. After starting the game again, a config file will be created under `BepInex/configs/SoulstoneTweaks.cfg`.

# Configuration & Features

NOTE: Configs do not get applied while the game is running, changing the config requires a restart!

### Disable Enemy AI

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Disable_Enemy_A_I`|`false`| When enabled, enemy AI is completely turned off. No attacks, no movement. |

Note: Boss health bars do not properly disappear after their death if they have no AI.

![DisableEnemyAI.gif](Img/DisableEnemyAI.gif)

### Unlock Zoom

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Unlock_Zoom`|`false`| Allows you to zoom in / out using your scroll wheel |

![UnlockZoom.png](Img/UnlockZoom.png)

### Time Modifier

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Time_Modifier`|`1.0`| Modifies game speed (affects **everything**). E.g. `2.0` doubles it.|

### Remove Map Obstacles

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Remove_Map_Obstacles`|`false`| Do you have trees? This option removes **ALL** obstacles from the map. Note: This may or may not work for future added maps.|

![RemoveMapObstacles.png](Img/RemoveMapObstacles.png)

### Skill Tree Cost Multiplier

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Skill_Tree_Cost_Multiplier`|`1.0`| Multiplier for all skill costs in the skill tree. Example: `2.0` doubles everything, `0` makes all skills free.|

Examples with `1000` or `0`:

<img src="Img/SkillTreeCostMultiplier1.png" width="250">
<img src="Img/SkillTreeCostMultiplier2.png" width="250">

### Curse Bonus Multiplier

|Config Entry|Default|Description|
|:----:|:---:|:---:|
|`Curse_Bonus_Multiplier`|`1.0`| Multiplier for all curse level bonuses|

<img src="Img/CurseBonusMultiplier.png" width="250">