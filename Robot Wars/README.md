# Robot Wars Implementation

## Dependencies

* Visual Studio 2017 RC or later, Community edition or upwards.
* C# 7.
* Nuget packages:
 * Moq 4.7.1 + Castle.Core.4.0.0
 * MSTest.TestAdapter 1.1.12
 * MSTest.TestFramework 1.1.11
 * Sprache 2.1.0

## Implementation notes

I selected Sprache for parsing, as it's lightweight and expressive, and it's easier to write a parser that's
obviously correct. For larger inputs, I'd use probably use something else.

Moq is used very lightly, primarily for simple property stubbing.

Where practical, I've applied Dependency Inversion. The obvious exception is the _ArenaFactory_, but I decided that the
additional code required to abstract obtaining the initial _IArena_ instance wasn't pragmatic for a project this size.

Because I decided to make Robots immutable, that meant that I also had to make them IDisposable too. Otherwise, a
caller might inadvertantly use a previous copy.

There are undoubtedly some tests missing that I haven't thought of, and ideally it should also have acceptance tests
to verify the interaction with the console.