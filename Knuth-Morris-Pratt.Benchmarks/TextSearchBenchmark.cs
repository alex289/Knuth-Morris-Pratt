using BenchmarkDotNet.Attributes;
using Knuth_Morris_Pratt.Comparisons;

namespace Knuth_Morris_Pratt.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class TextSearchBenchmark
{
    private const string Data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed nisl nec nisl lacinia luctus. Sed euismod, nisl sit amet aliquet aliquam, nisl nisl aliquet nisl, nec aliquet nisl forum";

    [Params("Lorem", "euismod", "forum")] public string Pattern;

    [Benchmark(Baseline = true)]
    public int OriginalIndexOf()
    {
        return Data.IndexOf(Pattern, StringComparison.Ordinal);
    }

    [Benchmark]
    public int KnuthMorrisPrattSearch()
    {
        return KnuthMorrisPrattAlgorithm.Search(Pattern, Data);
    }

    [Benchmark]
    public int NaiveSearch()
    {
        return NaiveAlgorithm.Search(Pattern, Data);
    }

    [Benchmark]
    public int BoyerMooreSearch()
    {
        return BoyerMooreAlgorithm.Search(Data, Pattern);
    }
}