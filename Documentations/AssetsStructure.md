# Assets Structures

Light description for all folders, files and classes.
_ _ _

**Table of Contents**
- [Resources](#resources)
- [Scripts](#scripts)
    - [Animations](#animations)
    - [Classes](#classes)
    - [Controller](#controller)
    - [Enemies](#enemies)
    - [Events](#events)
    - [Items](#items)
    - [Lore](#lore)
    - [Players](#players)
    - [Weapons](#weapons)

* * *

## Resources
[Assets/Resources/](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Resources/)

| File Name | Type | Dexcription |
|:---------:|:----:|-------------|
| PatternFoe.txt | Text | Text file to fill the manoeuvre list for random Spaceship pattern spawn. |
| PatternLore.txt | Text | Text file to fill the manoeuvre list for random Asteroids pattern spawn. |


* * *

## Scripts
Scripts for the game are locate in the folder [Assets/Scripts/Game/](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game)

_ _ _

### Animations
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Animations) contains scripts for the game animation.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| AttractTo.cs | Script | - | - | A GameObject will be attract to another GameObject when they will be near each other (the distance can be set) |
| BGScroller.cs | Script | - | - | Animate the star background scroller. |
| Follow.cs | Script | - | - | A GameObject will follow another GameObject without time delay and you can set a distance between them (Vector3, with Vector3(0,0,0) by default). |
| Grower.cs | Script | - | - | Make the GameObject scale grows. Use for bomb, laser and shield. |
| IAMover.cs | Script | - | - | Script test. Create a IA which avoid each player's shot. |
| Mover.cs | Script | - | - | Basic movement. A GameObject will move from the top to the bottom (speed can be set). |
| RandomRotator.cs | Script | - | - | A GameObject will rotate randomly. Use for asteroids. |
| SpecialMover.cs | Script | - | - | A GameObject will move according to a pattern |

_ _ _

### Classes
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Classes) contains generics classes.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| Constants.cs | Class | Static | - | Constants and small classes use in the project. |
| Items.cs | Class | Abstract | - | Abstract class for all items. |
| Lib.cs | Class | Static | - | Library with methode use in the project. |
| Lore.cs | Class | Abstract | - | Abstract class for all lore. |
| Ship.cs | Class | Abstract | - | Abstract class for all ship. |
| Weapon.cs | Class | Abstract | - | Abstract class for all weapon or shot. |

_ _ _

### Controller
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Controller) contains scripts for controller management.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| Arsenal.cs | Script | - | - | Weapon, shot manager. |
| DataController.cs | Script | - | - | Save data Manager. |
| GameController.cs | Script | - | - | Main game manager. |
| HazardsController.cs | Script | - | - | Lore and enemy spaceship spawning (with pattern library) manager. |
| ItemsController.cs | Script | - | - | Loot system manager. |
| KeyManager.cs | Script | - | - | Set up the UI display for key binding. |
| MenuController.cs | Script | - | - | Menu system manager. |
| ScoreManager.cs | Script | - | - | Set up the UI display for the score. |
| UIController.cs | Script | - | - | UI system (not the menu) manager. |

_ _ _

### Enemies
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Enemies) contains scripts for enemies.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| EnemyAction.cs | Script | - | - | Manage when the enemy'ship is firing. |
| EnemyController.cs | Script | - | Class/Ship.cs | Set collision condition. Set enemy's ship parameter (life and damage). |
| EnemyMovement.cs | Script | - | - | - |
| EvasiveManeuver.cs | Script | - | - | - |

_ _ _

### Events
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Events) contains event scripts management.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| ActiveByBoundary.cs | Script | - | - | Switch GameObject to not immortal when they enter the player's visibility. Avoid destroying enemies's ship or asteroids before they become visible. |
| DestroyByBoundary.cs | Script | - | - | Destroy any GameObject who leave the player's visibility. Avoid stacking GameObject. |
| DestroyByTime.cs | Script | - | - | Destroy GameObject after a time. |
| DestroyShotByTime.cs | Script | - | - | Old script to make shot exploding after a time. |

_ _ _

### Items
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Items) contains scripts for items.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| ArsenalUp.cs | Script | - | Class/Items.cs | Power Up the player's ship (more shot !!!). |
| BombUp.cs | Script | - | Class/Items.cs | Increase the number of bomb available. |
| EnergyUp.cs | Script | - | Class/Items.cs | Regenerate the player's energy for special wepaon. |
| LifeUp.cs | Script | - | Class/Items.cs | Increase the number of life available. |
| ScoreUp.cs | Script | - | Class/Items.cs | Give score points to the player. |

_ _ _

### Lore
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Lore) contains scripts for lores.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| AsteroidController.cs | Script | - | Class/Lore.cs | Set asteroid's life pool. Can only destroy the playership. |

_ _ _

### Players
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Players) contains scripts for player ship.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| PlayerAction.cs | Script | - | - | Allow the player to fire shot, bomb, switch etc... |
| PlayerController.cs | Script | - | Class/Ship.cs | Set collision condition. Set player's ship parameter (life, energy, bomb, blinking, respawn etc...). |
| PlayerMovement.cs | Script | - | - | Basic script for movement. WASD ou Arrow key listener. |

_ _ _

### Weapons
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Weapons) contains scripts for weapons.

| File Name | Type | State | Inheritance | Dexcription |
|:---------:|:----:|:-----:|:-----------:|-------------|
| Bomb.cs | Script | - | Class/Weapon.cs | Set collision condition. Can destroy lore, spaceship (enemy's) and shot (enemy's) |
| Laser.cs | Script | - | - | Create and initialize a laser. |
| Shot.cs | Script | - | Class/Weapon.cs | Set collision condition. Can destroy according to owner : enemy's ship/shot to player's ship/shot OR player's ship/shot to enemy's ship/shot. |
| SpecialWeapon.cs | Script | - | Class/Weapon.cs | Set collision condition. Can destroy lore, spaceship (enemy's) and shot (enemy's) |