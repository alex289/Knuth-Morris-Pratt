# Knuth-Morris-Pratt Algorithm

This repository contains an implementation of the Knuth-Morris-Pratt algorithm in C#. The KMP algorithm is a string searching algorithm that efficiently finds occurrences of a pattern within a larger text.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [Benchmarks](#benchmarks)

## Installation

To use this implementation of the KMP algorithm, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/Knuth-Morris-Pratt.git`
2. Restore the NuGet packages by running `dotnet restore` in the project directory.
3. Build the project by running `dotnet build` in the project directory.
4. Run the tests by running `dotnet test` in the project directory.

## Usage

To use the KMP algorithm, you can follow these steps:

1. Import the KMP module into your code: `using Knuth_Morris_Pratt;`
2. Create an instance of the KMP class: `var textSearchAlgorithm = new TextSearchAlgorithm();`
3. Call the `Search` method on the KMP instance, passing in the text and pattern as arguments: `textSearchAlgorithm.Search(pattern, text)`
4. The `Search` method will return the indices of all occurrences of the pattern within the text.

## Examples

Here's an example usage of the KMP algorithm:

```csharp
using Knuth_Morris_Pratt;

var textSearchAlgorithm = new TextSearchAlgorithm();
var pattern = "abc";
var text = "ababcabcababcabcabc";
var occurrencesAmount = textSearchAlgorithm.Search(pattern, text);
Console.WriteLine($"Pattern '{pattern}' occurs {occurrencesAmount} times in the text.");
```

## Benchmarks

The benchmarks can be found in the .Benchmark project.

**Set the configuration to Release Mode before running the benchmarks**
