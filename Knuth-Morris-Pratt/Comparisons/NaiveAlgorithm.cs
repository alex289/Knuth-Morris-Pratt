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
    public static int Search(string pattern, string text)
    {
        var n = text.Length;
        var m = pattern.Length;

        for (var i = 0; i <= n - m; i++)
        {
            int j;
            for (j = 0; j < m; j++)
            {
                if (text[i + j] != pattern[j])
                    break;
            }

            if (j == m)
                return i; // pattern found at index i
        }

        return -1; // pattern not found in text
    }
}