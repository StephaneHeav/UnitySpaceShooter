# Patterns Library

## Description

I create this library to display pattern easily. It is build based on this [Bestiary management](https://theliquidfire.wordpress.com/2014/12/25/bestiary-management-and-scriptable-objects/).

Trajectory is a template for trajectory implementation. For example, a line, a oscillation etc...

Formation is a group of trajectory (simultaneous).

Manoeuvre is the formation's order with time after each of them.

## Classes

- [LoadResources.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/LoadResources.md): you can load a file.
	`LoadResources.LoadTxtAsListString ("filename")`
- [Manoeuvres.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Manoeuvres.md): set a Manoeuvres from a string.
	`Manoeuvre.Create(string)`
- [Formation.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Formation.md): set a Formation by Manoeuvres.
- [Trajectory.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Trajectory.md): abstract class for trajectory.
- [TrajectoryLine.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/TrajectoryLine.md): set a linear trajectory by Formation.
- [TrajectoryZigZag.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/TrajectoryZigZag.md): set a oscillate trajectory by Formation.

## How to use :

- A Trajectory has a name and arguments based on the Trajectory name. It is separate by `#`. After `#`, it is the inherited Trajectory which parse the arguments.

		TrajectoryZigZag#(-1,0,20)(1,0,-7)(2,1,1)
		TrajectoryLine#(-3,0,20)(-3,0,-7)

- A Formation has one or many Trajectory separate by `|` and a time (seconde) at the end separate by `=`.

		TrajectoryZigZag#(-1,0,20)(1,0,-7)(2,1,1)|TrajectoryLine#(-3,0,20)(-3,0,-7)=0.5

- A Manoeuvre has one or many Formation separate by `;`.

		TrajectoryZigZag#(-1,0,20)(1,0,-7)(2,1,1)|TrajectoryLine#(-3,0,20)(-3,0,-7)=0.5;TrajectoryZigZag#(-1,0,20)(1,0,-7)(2,1,1)|TrajectoryLine#(-3,0,20)(-3,0,-7)=0.5

