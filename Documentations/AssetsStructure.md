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

- PatternFoe.txt
	Text file to fill the manoeuvre list for random Spaceship pattern spawn.

- PatternLore.txt
	Text file to fill the manoeuvre list for random Asteroids pattern spawn.

* * *

## Scripts
Scripts for the game are locate in the folder [Assets/Scripts/Game/](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game)

_ _ _

### Animations
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Animations) contains scripts for the game animation.

- AttractTo.cs
	A GameObject will be attract to another GameObject when they will be near each other (the distance can be set).

- BGScroller.cs
	Animate the star background scroller.

- Follow.cs
	A GameObject will follow another GameObject without time delay and you can set a distance between them (Vector3, with Vector3(0,0,0) by default).

- Grower.cs
	Make the GameObject scale grows. Use for bomb, laser and shield.

- IAMover.cs
	Script test. Create a IA which avoid each player's shot.

- Mover.cs
	Basic movement. A GameObject will move from the top to the bottom (speed can be set).

- RandomRotator.cs
	A GameObject will rotate randomly. Use for asteroids.

- SpecialMover.cs
	A GameObject will move according to a pattern

_ _ _

### Classes
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Classes) contains generics classes.

- Constants.cs
	Constants and small classes use in the project.
- Items.cs
    Abstract class for all items.
- Lib.cs
    Library with methode use in the project.
- Lore.cs
	Abstract class for all lore.
- Ship.cs
	Abstract class for all ship.
- Weapon.cs
	Abstract class for all weapon or shot.

_ _ _

### Controller
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Controller) contains scripts for controller management.

- Arsenal.cs
	Weapon, shot manager.
- DataController.cs
	Save data Manager.
- GameController.cs
	Main game manager.
- HazardsController.cs
	Lore and enemy spaceship spawning (with pattern library) manager.
- ItemsController.cs
	Loot system manager.
- KeyManager.cs
	Set up the UI display for key binding.
- MenuController.cs
	Menu system manager.
- ScoreManager.cs
	Set up the UI display for the score.
- UIController.cs
	UI system (not the menu) manager.

_ _ _

### Enemies
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Enemies) contains scripts for enemies.

- EnemyAction.cs
	Manage when the enemy'ship is firing.

- EnemyController.cs
	Inherit from Class/Ship.cs
    Set collision condition.
    Set enemy's ship parameter (life and damage).

- EnemyMovement.cs
	Empty

- EvasiveManeuver.cs
	Not use.

_ _ _

### Events
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Events) contains event scripts management.

- ActiveByBoundary.cs
	Switch GameObject to not immortal when they enter the player's visibility.
    Avoid destroying enemies's ship or asteroids before they become visible.

- DestroyByBoundary.cs
	Destroy any GameObject who leave the player's visibility.
    Avoid stacking GameObject.

- DestroyByTime.cs
	Destroy GameObject after a time.

- DestroyShotByTime.cs
	Old script to make shot exploding after a time.

_ _ _

### Items
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Items) contains scripts for items.

- ArsenalUp.cs
	Inherit from Class/Items.cs
    Power Up the player's ship (more shot !!!).

- BombUp.cs
	Inherit from Class/Items.cs
    Increase the number of bomb available.

- EnergyUp.cs
	Inherit from Class/Items.cs
    Regenerate the player's energy for special wepaon.

- LifeUp.cs
	Inherit from Class/Items.cs
    Increase the number of life available.

- ScoreUp.cs
	Inherit from Class/Items.cs
    Give score points to the player.

_ _ _

### Lore
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Lore) contains scripts for lores.

- AsteroidController.cs
	Inherit from Class/Lore.cs
    Set asteroid's life pool.
    Can only destroy the playership.

_ _ _

### Players
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Players) contains scripts for player ship.

- PlayerAction.cs
	Allow the player to fire shot, bomb, switch etc...

- PlayerController.cs
	Inherit from Class/Ship.cs
    Set collision condition.
    Set player's ship parameter (life, energy, bomb, blinking, respawn etc...).

- PlayerMovement.cs
	Basic script for movement. WASD ou Arrow key listener.

_ _ _

### Weapons
[This folder](https://github.com/StephaneHeav/UnitySpaceShooter/tree/master/Assets/Scripts/Game/Weapons) contains scripts for weapons.

- Bomb.cs
	Inherit from Class/Weapon.cs
    Set collision condition.
    Can destroy lore, spaceship (enemy's) and shot (enemy's)

- Laser.cs
	Create and initialize a laser.

- Shot.cs
	Inherit from Class/Weapon.cs
    Set collision condition.
    Can destroy according to owner :
    - enemy's ship/shot to player's ship/shot
    - player's ship/shot to enemy's ship/shot.

- SpecialWeapon.cs
	Inherit from Class/Weapon.cs
    Set collision condition.
    Can destroy lore, spaceship (enemy's) and shot (enemy's)