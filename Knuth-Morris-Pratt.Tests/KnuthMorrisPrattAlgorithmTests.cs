using FluentAssertions;
using Xunit;

namespace Knuth_Morris_Pratt.Tests;

public class KnuthMorrisPrattAlgorithmTests
{
    [Fact]
    public void Should_Create_Prefix_Table_Correctly()
    {
        var pattern = "ababcabab";

        var prefixTable = KnuthMorrisPrattAlgorithm.PrefixAnalysis(pattern);
        prefixTable.Should().BeEquivalentTo([0, 0, 1, 2, 0, 1, 2, 3, 4]);
    }

    [Fact]
    public void Should_Find_Pattern_Correctly()
    {
        var pattern = "ABCDABD";
        var text = "ABC ABCDAB ABCDABCDABDE";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));

        // Manually getting the prefix table should also work
        var prefixTable = KnuthMorrisPrattAlgorithm.PrefixAnalysis(pattern);
        var resultWithPrefixTable = KnuthMorrisPrattAlgorithm.Search(pattern, prefixTable, text);

        resultWithPrefixTable.Should().Be(result);
    }

    [Fact]
    public void Should_Not_Find_Any_Pattern()
    {
        var pattern = "Pizza";
        var text = "asdasdasdasdadsPiasdasdaasdnasdasd";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }

    [Fact]
    public void Should_Respect_Casing()
    {
        var pattern = "pIZZa";
        var text = "asdasdaPizzasdasdadspIZZaasdnasdasd";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }
}