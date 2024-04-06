using FluentAssertions;
using Knuth_Morris_Pratt.Comparisons;
using Xunit;

namespace Knuth_Morris_Pratt.Tests;

public class NaiveAlgorithmTests
{
    [Fact]
    public void Should_Find_Pattern_Amount_Correctly()
    {
        var pattern = "ABCDABD";
        var text = "ABC ABCDAB ABCDABCDABDE";

        var result = NaiveAlgorithm.Search(pattern, text);
        result.Should().Be(1);
    }

    [Fact]
    public void Should_Not_Find_Any_Pattern_Amount()
    {
        var pattern = "Pizza";
        var text = "asdasdasdasdadsPiasdasdaasdnasdasd";

        var result = NaiveAlgorithm.Search(pattern, text);
        result.Should().Be(0);
    }

    [Fact]
    public void Should_Find_Multiple_Occurences()
    {
        var pattern = "Pizza";
        var text = "asdasdaPisdasdadsPizzaasdnasdasdasdasdaPisdasdadsPizzaasdnasdasd";

        var result = NaiveAlgorithm.Search(pattern, text);
        result.Should().Be(2);
    }

    [Fact]
    public void Should_Respect_Casing()
    {
        var pattern = "pIZZa";
        var text = "asdasdaPizzasdasdadspIZZaasdnasdasd";

        var result = NaiveAlgorithm.Search(pattern, text);
        result.Should().Be(1);
    }
}