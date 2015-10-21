# Pattern Library

## Description

I create this library to display pattern easily.
A pattern is a trajectory for a GameObject.
A formation is a group of trajectory for GameObject (simultaneous).
A manoeuvre is the formation's order with time after each of them.

## Classes

- [LoadResources.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/LoadResources.md): you can load a file.
	`LoadResources.LoadTxtAsListString ("filename")`
- [Manoeuvres.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Manoeuvres.md): set a Manoeuvres from a string.
	`Manoeuvre.Create(string)`
- [Formation.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Formation.md): set a Formation by Manoeuvres.
- [Pattern.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/Pattern.md): abstract class for pattern.
- [PatternLine.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/PatternLine.md): set a linear Pattern by Formation.
- [PatternZigZag.cs](https://github.com/StephaneHeav/UnitySpaceShooter/blob/master/Assets/Scripts/Lib/Patterns/Documentations/Classes/PatternZigZag.md): set a oscillate Pattern by Formation.

## How to use :

- A Pattern has a name and arguments depending on the pattern name. It is separate by `#`. After `#`, it is the inherited Pattern which parse the arguments.
		PatternZigZag#(-1,0,20)(1,0,-7)(2,1,1)
		PatternLine#(-3,0,20)(-3,0,-7)

- A Formation has one or many Pattern separate by `|` and a time (seconde) at the end separate by `=`.
		PatternZigZag#(-1,0,20)(1,0,-7)(2,1,1)|PatternLine#(-3,0,20)(-3,0,-7)=0.5

- A Manoeuvre has one or many Formation separate by `;`.
		PatternZigZag#(-1,0,20)(1,0,-7)(2,1,1)|PatternLine#(-3,0,20)(-3,0,-7)=0.5;PatternZigZag#(-1,0,20)(1,0,-7)(2,1,1)|PatternLine#(-3,0,20)(-3,0,-7)=0.5

