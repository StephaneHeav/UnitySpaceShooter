# Class LoadResources

- [Constructor](#constructor)
- [Destructor](#destructor)
- [Variables](#variables)
- [Methodes](#methodes)
	- [LoadTxtAsString](#loadtxtasstring)

## Constructor

## Destructor

## Variables

## Methodes

### LoadTxtAsString

| Visibility | State | Return |
|:----------:|:-----:|:------:|
| public | static | List<string> |

- Arguments:
| Name | Type | Description |
|:----:|:----:|-------------|
| filename | string | file's name in Assets/Resources |

Open the file from Assets/Resources/filename, get the text and split by `\n`. Fill a List<string> with each line from the file and return the List<string> created.
Return an empty List<string> if an exception occured.
