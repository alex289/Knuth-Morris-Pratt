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
        prefixTable.Should().BeEquivalentTo([-1, 0, 0, 1, 2, 0, 1, 2, 3, 4]);
    }

    [Fact]
    public void Should_Find_Pattern_Amount_Correctly()
    {
        var pattern = "ABCDABD";
        var text = "ABC ABCDAB ABCDABCDABDE";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(1);

        // Manually getting the prefix table should also work
        var prefixTable = KnuthMorrisPrattAlgorithm.PrefixAnalysis(pattern);
        var resultWithPrefixTable = KnuthMorrisPrattAlgorithm.Search(pattern, prefixTable, text);

        resultWithPrefixTable.Should().Be(result);
    }

    [Fact]
    public void Should_Not_Find_Any_Pattern_Amount()
    {
        var pattern = "Pizza";
        var text = "asdasdasdasdadsPiasdasdaasdnasdasd";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(0);
    }

    [Fact]
    public void Should_Find_Multiple_Occurences()
    {
        var pattern = "Pizza";
        var text = "asdasdaPisdasdadsPizzaasdnasdasdasdasdaPisdasdadsPizzaasdnasdasd";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(2);
    }

    [Fact]
    public void Should_Respect_Casing()
    {
        var pattern = "pIZZa";
        var text = "asdasdaPizzasdasdadspIZZaasdnasdasd";

        var result = KnuthMorrisPrattAlgorithm.Search(pattern, text);
        result.Should().Be(1);
    }
}