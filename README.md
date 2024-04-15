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
| Method                 | Pattern | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------------- |-------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| **OriginalIndexOf**        | **euismod** |  **19.242 ns** | **0.0391 ns** | **0.0366 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | euismod | 118.144 ns | 0.5958 ns | 0.4975 ns |  6.14 |    0.03 | 0.0088 |      56 B |          NA |
| NaiveSearch            | euismod |  93.230 ns | 0.0982 ns | 0.0820 ns |  4.84 |    0.01 |      - |         - |          NA |
| BoyerMooreSearch       | euismod | 250.480 ns | 0.3153 ns | 0.2950 ns | 13.02 |    0.03 | 0.1760 |    1104 B |          NA |
|                        |         |            |           |           |       |         |        |           |             |
| **OriginalIndexOf**        | **forum**   |  **22.419 ns** | **0.1191 ns** | **0.1114 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | forum   | 167.641 ns | 0.1283 ns | 0.1071 ns |  7.47 |    0.04 | 0.0076 |      48 B |          NA |
| NaiveSearch            | forum   | 150.842 ns | 0.0953 ns | 0.0892 ns |  6.73 |    0.03 |      - |         - |          NA |
| BoyerMooreSearch       | forum   | 374.263 ns | 0.7846 ns | 0.7340 ns | 16.69 |    0.10 | 0.1745 |    1096 B |          NA |
|                        |         |            |           |           |       |         |        |           |             |
| **OriginalIndexOf**        | **Lorem**   |   **6.767 ns** | **0.0050 ns** | **0.0047 ns** |  **1.00** |    **0.00** |      **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | Lorem   |  15.052 ns | 0.0179 ns | 0.0168 ns |  2.22 |    0.00 | 0.0076 |      48 B |          NA |
| NaiveSearch            | Lorem   |   2.991 ns | 0.0035 ns | 0.0031 ns |  0.44 |    0.00 |      - |         - |          NA |
| BoyerMooreSearch       | Lorem   | 142.236 ns | 0.1946 ns | 0.1821 ns | 21.02 |    0.03 | 0.1745 |    1096 B |          NA |
