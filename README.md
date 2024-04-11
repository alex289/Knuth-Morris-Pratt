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

var occurrencesIndex = KnuthMorrisPrattAlgorithm.Search(pattern, text);
Console.WriteLine($"Pattern '{pattern}' occurs at index {occurrencesIndex}.");
```

## Benchmarks

The benchmarks can be found in the .Benchmark project and compare the KMP with the naive string search and the boyer moore string search algorithms.

**Set the configuration to Release Mode before running the benchmarks**

### My Results

```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD


```
| Method                 | StringLength | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| **OriginalIndexOf**        | **1**            |  **14.29 ns** | **0.020 ns** | **0.018 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | 1            |  96.22 ns | 0.203 ns | 0.180 ns |  6.73 |    0.01 | 0.0076 |      48 B |          NA |
| NaiveSearch            | 1            |  76.70 ns | 0.091 ns | 0.081 ns |  5.37 |    0.01 |      - |         - |          NA |
| BoyerMooreSearch       | 1            | 239.31 ns | 0.660 ns | 0.585 ns | 16.74 |    0.05 | 0.1745 |    1096 B |          NA |
|                        |              |           |          |          |       |         |        |           |             |
| **OriginalIndexOf**        | **50**           |  **14.33 ns** | **0.019 ns** | **0.018 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | 50           |  96.22 ns | 0.143 ns | 0.119 ns |  6.72 |    0.01 | 0.0076 |      48 B |          NA |
| NaiveSearch            | 50           |  77.21 ns | 0.145 ns | 0.121 ns |  5.39 |    0.01 |      - |         - |          NA |
| BoyerMooreSearch       | 50           | 238.41 ns | 0.596 ns | 0.498 ns | 16.64 |    0.04 | 0.1745 |    1096 B |          NA |
|                        |              |           |          |          |       |         |        |           |             |
| **OriginalIndexOf**        | **100**          |  **14.28 ns** | **0.020 ns** | **0.019 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | 100          |  96.18 ns | 0.119 ns | 0.111 ns |  6.73 |    0.01 | 0.0076 |      48 B |          NA |
| NaiveSearch            | 100          |  76.68 ns | 0.086 ns | 0.072 ns |  5.37 |    0.01 |      - |         - |          NA |
| BoyerMooreSearch       | 100          | 239.26 ns | 0.728 ns | 0.681 ns | 16.75 |    0.06 | 0.1745 |    1096 B |          NA |

