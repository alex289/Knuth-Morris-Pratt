using BenchmarkDotNet.Attributes;
using Knuth_Morris_Pratt.Comparisons;

namespace Knuth_Morris_Pratt.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class TextSearchBenchmark
{
    private string _data = null!;
    private string _pattern = null!;

    [Params(1, 10, 50, 100)] public int StringLength;

    [GlobalSetup]
    public void Setup()
    {
        const string initialText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed nisl nec nisl lacinia luctus. Sed euismod, nisl sit amet aliquet aliquam, nisl nisl aliquet nisl, nec aliquet nisl nisl s";

        for (var i = 0; i < StringLength; i++)
        {
            _data += initialText + " ";
        }

        _pattern = "luctus";
    }

    [Benchmark(Baseline = true)]
    public int OriginalIndexOf()
    {
        return _data.IndexOf(_pattern, StringComparison.Ordinal);
    }

    [Benchmark]
    public int KnuthMorrisPrattSearch()
    {
        return KnuthMorrisPrattAlgorithm.Search(_data, _pattern);
    }

    [Benchmark]
    public int NaiveSearch()
    {
        return NaiveAlgorithm.Search(_data, _pattern);
    }

    [Benchmark]
    public int BoyerMooreSearch()
    {
        return BoyerMooreAlgorithm.Search(_data, _data);
    }
}