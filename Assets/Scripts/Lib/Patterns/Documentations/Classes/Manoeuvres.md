# Class Manoeuvres

- [Constructor](#constructor)
- [Destructor](#destructor)
- [Variables](#variables)
- [Methodes](#methodes)
	- [Create](#create)
	- [StartManoeuvre](#startmanoeuvre)
	- [GetNextFormation](#getnextformation)

## Constructor

## Destructor

## Variables

| Visibility | State | Name | Type | Description |
|:----------:|:-----:|:----:|:----:|-------------|
| public | - | manoeuvre | Formation[] | Formation's array |
| private | - | timeToSpend | float | Time to spend for this manoeuvre |
| private | - | lastFormation | int | Cursor for the last formation returned |

## Methodes

### Create

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | static | Manoeuvre |

- Arguments:
| Name | Type | Description |
|:----:|:----:|-------------|
| manoeuvreString | string | string to parse |

Initialize and fill the formation's array with formation from the parsed string.

### StartManoeuvre

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | - | float |

- Arguments: none

Initialize the manoeuvre for reading purpose.

### GetNextFormation

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | - | Formation |

- Arguments: none

Return the next formation (with the cursor) or null if it is finished.