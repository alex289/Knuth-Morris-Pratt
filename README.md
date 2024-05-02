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

The text used for the benchmarks is "The Great Gatsby" by F. Scott Fitzgerald from the Project Gutenberg. The patterns used for the benchmarks is "facility", "thatched", and "Zelda" which represent words from the start, middle and end of the text.

**Set the configuration to Release Mode before running the benchmarks**

### My Results

```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.0 (8.0.23.53103), Arm64 RyuJIT AdvSIMD


```
| Method                 | Pattern  | Mean         | Error       | StdDev      | Median       | Ratio  | RatioSD | Gen0     | Gen1     | Gen2    | Allocated | Alloc Ratio |
|----------------------- |--------- |-------------:|------------:|------------:|-------------:|-------:|--------:|---------:|---------:|--------:|----------:|------------:|
| **OriginalIndexOf**        | **facility** |  **29,284.5 ns** |    **41.59 ns** |    **38.90 ns** |  **29,267.4 ns** |   **1.00** |    **0.00** |        **-** |        **-** |       **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | facility | 262,096.8 ns |   174.57 ns |   163.29 ns | 262,077.6 ns |   8.95 |    0.01 |        - |        - |       - |      56 B |          NA |
| NaiveSearch            | facility | 256,677.1 ns |   158.16 ns |   147.95 ns | 256,638.2 ns |   8.76 |    0.01 |        - |        - |       - |         - |          NA |
| BoyerMooreSearch       | facility | 213,310.1 ns | 1,384.86 ns | 1,295.40 ns | 213,120.9 ns |   7.28 |    0.04 | 232.6660 | 232.6660 | 66.6504 |  262403 B |          NA |
|                        |          |              |             |             |              |        |         |          |          |         |           |             |
| **OriginalIndexOf**        | **thatched** |  **15,903.1 ns** |    **10.20 ns** |     **9.04 ns** |  **15,905.0 ns** |   **1.00** |    **0.00** |        **-** |        **-** |       **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | thatched | 169,320.8 ns |   323.91 ns |   270.48 ns | 169,287.4 ns |  10.65 |    0.02 |        - |        - |       - |      56 B |          NA |
| NaiveSearch            | thatched | 166,236.2 ns |   680.59 ns |   636.63 ns | 166,226.0 ns |  10.46 |    0.04 |        - |        - |       - |         - |          NA |
| BoyerMooreSearch       | thatched | 135,909.5 ns | 2,676.72 ns | 4,167.34 ns | 133,725.5 ns |   8.73 |    0.28 | 233.3984 | 233.3984 | 66.4063 |  262389 B |          NA |
|                        |          |              |             |             |              |        |         |          |          |         |           |             |
| **OriginalIndexOf**        | **Zelda**    |     **133.6 ns** |     **0.56 ns** |     **0.52 ns** |     **133.9 ns** |   **1.00** |    **0.00** |        **-** |        **-** |       **-** |         **-** |          **NA** |
| KnuthMorrisPrattSearch | Zelda    |     990.3 ns |     0.73 ns |     0.68 ns |     990.2 ns |   7.41 |    0.03 |   0.0076 |        - |       - |      48 B |          NA |
| NaiveSearch            | Zelda    |     983.9 ns |     4.00 ns |     3.34 ns |     983.1 ns |   7.36 |    0.04 |        - |        - |       - |         - |          NA |
| BoyerMooreSearch       | Zelda    |  77,068.6 ns |   398.64 ns |   372.89 ns |  77,028.1 ns | 576.76 |    3.85 | 233.2764 | 233.2764 | 66.6504 |  262368 B |          NA |
