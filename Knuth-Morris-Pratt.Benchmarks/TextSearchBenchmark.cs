using BenchmarkDotNet.Attributes;
using Knuth_Morris_Pratt.Comparisons;

namespace Knuth_Morris_Pratt.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class TextSearchBenchmark
{
    private string _data = string.Empty;

    [Params("Zelda", "thatched", "facility")]
    public string Pattern;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        _data = File.ReadAllText("Data.txt");
    }

    [Benchmark(Baseline = true)]
    public int OriginalIndexOf()
    {
        return _data.IndexOf(Pattern, StringComparison.Ordinal);
    }

    [Benchmark]
    public int KnuthMorrisPrattSearch()
    {
        return KnuthMorrisPrattAlgorithm.Search(Pattern, _data);
    }

    [Benchmark]
    public int NaiveSearch()
    {
        return NaiveAlgorithm.Search(Pattern, _data);
    }

    [Benchmark]
    public int BoyerMooreSearch()
    {
        return BoyerMooreAlgorithm.Search(_data, Pattern);
    }
}