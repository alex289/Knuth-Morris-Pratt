using BenchmarkDotNet.Attributes;
using Knuth_Morris_Pratt.Comparisons;

namespace Knuth_Morris_Pratt.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class TextSearchBenchmark
{
    private string data = null!;
    private string pattern = null!;

    [Params(1, 10, 50, 100)]
    public int StringLength;

    [GlobalSetup]
    public void Setup()
    {
        var initialText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sed nisl nec nisl lacinia luctus. Sed euismod, nisl sit amet aliquet aliquam, nisl nisl aliquet nisl, nec aliquet nisl nisl s";

        for (var i = 0; i < StringLength; i++)
        {
            data += initialText;
        }

        pattern = "luctus";
    }

    [Benchmark]
    public int KnuthMorrisPrattSearch() => KnuthMorrisPrattAlgorithm.Search(data, pattern);

    [Benchmark]
    public int NaiveSearch() => NaiveAlgorithm.Search(data, pattern);

    [Benchmark]
    public int BoyerMooreSearch() => BoyerMooreAlgorithm.Search(data, pattern);
}