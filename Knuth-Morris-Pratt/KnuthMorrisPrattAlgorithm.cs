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
    public static int[] PrefixAnalysis(ReadOnlySpan<char> pattern)
    {
        int i = 0, prefixLength = -1;
        var prefixTable = new int[pattern.Length + 1];
        prefixTable[i]=prefixLength;

        while (i<pattern.Length)
        {
            while (prefixLength >= 0 && pattern[i] != pattern[prefixLength])
            {
                prefixLength=prefixTable[prefixLength];
            }

            i++;
            prefixLength++;

            prefixTable[i]=prefixLength;
        }

        return prefixTable;
    }

    /// <summary>
    ///     Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(ReadOnlySpan<char> pattern, ReadOnlySpan<char> text)
    {
        var prefixTable = PrefixAnalysis(pattern);
        var j = 0;
        for (var i = 0; i < text.Length; i++)
        {
            while (j > 0 && pattern[j] != text[i])
            {
                j = prefixTable[j];
            }

            if (pattern[j] == text[i])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                return i - j + 1;
            }
        }

        return -1;
    }
}
