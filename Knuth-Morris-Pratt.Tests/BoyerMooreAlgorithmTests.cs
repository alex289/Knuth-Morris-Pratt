using FluentAssertions;
using Knuth_Morris_Pratt.Comparisons;
using Xunit;

namespace Knuth_Morris_Pratt.Tests;

public class BoyerMooreAlgorithmTests
{
    [Fact]
    public void Should_Find_Pattern_Correctly()
    {
        var pattern = "ABCDABD";
        var text = "ABC ABCDAB ABCDABCDABDE";

        var result = BoyerMooreAlgorithm.Search(text, pattern);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }

    [Fact]
    public void Should_Not_Find_Any_Pattern()
    {
        var pattern = "Pizza";
        var text = "asdasdasdasdadsPiasdasdaasdnasdasd";

        var result = BoyerMooreAlgorithm.Search(text, pattern);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }

    [Fact]
    public void Should_Find_Multiple_Occurences()
    {
        var pattern = "Pizza";
        var text = "asdasdaPisdasdadsPizzaasdnasdasdasdasdaPisdasdadsPizzaasdnasdasd";

        var result = BoyerMooreAlgorithm.Search(text, pattern);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }

    [Fact]
    public void Should_Respect_Casing()
    {
        var pattern = "pIZZa";
        var text = "asdasdaPizzasdasdadspIZZaasdnasdasd";

        var result = BoyerMooreAlgorithm.Search(text, pattern);
        result.Should().Be(text.IndexOf(pattern, StringComparison.Ordinal));
    }
}