# Labeler
![CI](https://github.com/KonKri/Labeler/workflows/CI/badge.svg) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Labeler.Core)

Labeler is a NuGet package that allows for adding Labels easily onto Enum fields to 
use when there is a need to present information quickly to a view in an elegant way.


## Contents
[The problem](#the-problem)

[Installation](#installation)

[How to use](#how-to-use)


## The problem
Imagine having an enum where some of its fields consist of multiple words like the enum below:

```C#
enum SteakDoneness
{
    Rare,
    MediumRare,
    Medium,
    MediumWell,
    WellDone,
}
```
In case we want to print an enum value we will have the following result which is not the most elegant:

```C#
Console.WriteLine($"I ordered a {SteakDoneness.MediumWell} steak.");
```

```
I ordered a MediumWell steak.
```

## Installation
You can install the library by searching into the NuGet library or by running the following command:

```PM> Install-Package Labeler.Core -Version 0.1.0-alpha```

## How to Use
### Add the label attributes onto enum fields

```C#
enum SteakDoneness
{
    Rare,
    
    [Label("Medium Rare")]
    MediumRare,
    
    Medium,
    
    [Label("Medium Well")]
    MediumWell,
    
    [Label("Well Done")]
    [Label("Well")] // "Well Done" level can be descrbed just as "Well" as well...
    WellDone,
}
```
As you can see we can have multiple label attributes decorating some fields, while totally ignoring others that don't need any labeling.


### ```.GetLabel()```
To get the Label's Value, simply just call the ```.GetLabel()``` extention method on any enum type. Upon that, you can use methods that you would use upon a regular string value.

Example:
```C#
Console.WriteLine($"I ordered a {SteakDoneness.MediumWell.GetLabel().ToLower()} steak.");
```
```
I ordered a medium well steak.
```

In case there is no labeling, the enum's field name will be returned as string, as it would when using ```.ToString()```.

In case there are multiple labels decorating the enum's field, the first will be returned.


### ```.GetLabels()``` 
To get the Label's values as ```IEnumerable<string>```, simply call the ```.GetLabels()``` extention method on any enum type. Upon that, you can use LINQ methods to get the first or last string label or apply your logic.

Example:
```C#
Console.WriteLine($"I ordered a {SteakDoneness.WellDone.GetLabels().First().ToLower()} steak.");
```
```
I ordered a well done steak.
```

