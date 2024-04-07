namespace Knuth_Morris_Pratt;

/// <summary>
///     This class implements the Knuth-Morris-Pratt text search algorithm.
/// </summary>
public static class KnuthMorrisPrattAlgorithm
{
    /// <summary>
    ///     Analyzes the given pattern and creates a prefix table.
    /// </summary>
    /// <param name="pattern">The pattern to analyze.</param>
    /// <returns>The prefix table for the given pattern.</returns>
    public static int[] PrefixAnalysis(string pattern)
    {
        var prefixTable = new int[pattern.Length];
        var prefixLength = 0;

        for (var i = 1; i < pattern.Length; i++)
        {
            while (prefixLength > 0 && pattern[prefixLength] != pattern[i])
            {
                prefixLength = prefixTable[prefixLength - 1];
            }

            if (pattern[prefixLength] == pattern[i])
            {
                prefixLength++;
            }

            prefixTable[i] = prefixLength;
        }

        return prefixTable;
    }

    /// <summary>
    ///     Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(string pattern, string text)
    {
        var prefixTable = PrefixAnalysis(pattern);
        return Search(pattern, prefixTable, text);
    }

    /// <summary>
    ///     Searches for the given pattern in the given text using the provided prefix table.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="prefixTable">The prefix table to use for the search.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(string pattern, int[] prefixTable, string text)
    {
        var j = 0;
        for (var i = 0; i < text.Length; i++)
        {
            while (j > 0 && pattern[j] != text[i])
            {
                j = prefixTable[j - 1];
            }

            if (pattern[j] == text[i])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                return i - j + 1; // pattern found at index i - j + 1
            }
        }

        return -1; // pattern not found in text
    }
}