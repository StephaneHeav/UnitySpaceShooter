# Class PatternZigZag

Inherit : Pattern

- [Constructor](#constructor)
- [Destructor](#destructor)
- [Variables](#variables)
- [Methodes](#methodes)
	- [Set](#set)
	- [GetNextPosition](#getnextposition)
	- [GetClone](#getclone)

## Constructor

## Destructor

## Variables

| Visibility | State | Name | Type | Description |
|:----------:|:-----:|:----:|:----:|-------------|
| public | inherit | posStart | Vector3 | Define the initial position for the pattern |
| protected | inherit | savePatternString | string | Save the string which is parse to set the pattern |
| public | - | posEnd | Vector3 | Define the last position for the pattern |
| private | - | amplitudeX | float | Default value for the amplitude in the X axis |
| private | - | amplitudeZ | float | Default value for the amplitude in the Z axis |
| private | - | linearPos | Vector3 | Save the current lineaire position |
| private | - | direction | float | Define the direction Sin(x) ou -Sin(x) |

## Methodes

### Set

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | override | void |

- Arguments:
| Name | Type | Description |
|:----:|:----:|-------------|
| patternString  | string | string to parse |

Initialize the Pattern Object with the string.

### GetNextPosition

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | override | Vector3 |

- Arguments:
| Name | Type | Description |
|:----:|:----:|-------------|
| currPos  | Vector3 | string to parse |
| deltaTime  | float | string to parse |
| speed  | float | string to parse |

Return the next position for a oscillate curve (relative to the linear trajectory).

### GetClone

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | override | Pattern  |

- Arguments: none

Return a clone of the current object