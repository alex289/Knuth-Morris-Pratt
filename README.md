# Knuth-Morris-Pratt Algorithm

This repository contains an implementation of the Knuth-Morris-Pratt algorithm in C#. The KMP algorithm is a string searching algorithm that efficiently finds occurrences of a pattern within a larger text.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Benchmarks](#benchmarks)

## Installation

> Requires .NET 8

To use this implementation of the KMP algorithm, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/Knuth-Morris-Pratt.git`
2. Restore the NuGet packages by running `dotnet restore` in the project directory.
3. Build the project by running `dotnet build` in the project directory.
4. Run the tests by running `dotnet test` in the project directory.

## Usage

To use the KMP algorithm, use it like this:

```csharp
using Knuth_Morris_Pratt;

var pattern = "ABCDABD";
var text = "ABC ABCDAB ABCDABCDABDE";

var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
Console.WriteLine($"Pattern '{pattern}' occurs {occurrencesAmount} times in the text.");
```

## Benchmarks

The benchmarks can be found in the .Benchmark project and compare the KMP with the naive string search and the boyer moore string search algorithms.

**Set the configuration to Release Mode before running the benchmarks**
