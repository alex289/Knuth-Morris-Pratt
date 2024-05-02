namespace Knuth_Morris_Pratt.Comparisons;

/// <summary>
///     This class implements a naive text search algorithm.
/// </summary>
public static class NaiveAlgorithm
{
    /// <summary>
    ///     Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(ReadOnlySpan<char> pattern, ReadOnlySpan<char> text)
    {
        var n = text.Length;
        var m = pattern.Length;

        var i=0;
        while (i<=n-m)
        {
            var j = 0;
            while (j<m && pattern[j]==text[i+j]) j++;
            if (j==m) return i;
            i++;
        }

        return -1;
    }
}