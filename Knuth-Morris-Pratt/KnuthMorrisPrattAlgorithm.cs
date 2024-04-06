namespace Knuth_Morris_Pratt;

/// <summary>
/// This class implements the Knuth-Morris-Pratt text search algorithm.
/// </summary>
public static class KnuthMorrisPrattAlgorithm
{
    /// <summary>
    /// Analyzes the given pattern and creates a prefix table.
    /// </summary>
    /// <param name="pattern">The pattern to analyze.</param>
    /// <returns>The prefix table for the given pattern.</returns>
    public static int[] PrefixAnalysis(string pattern)
    {
        var prefixLength = -1;
        var prefixTable = new int[pattern.Length + 1];

        prefixTable[0] = prefixLength; // The first element is always -1

        for (var i = 0; i <= pattern.Length - 1; i++)
        {
            // while a found prefix can't be extended, look for a shorter one
            while (prefixLength >= 0 && pattern[prefixLength] != pattern[i])
            {
                prefixLength = prefixTable[prefixLength];
            }

            prefixLength++;
            prefixTable[i + 1] = prefixLength; // Add the found prefix length to the table
        }

        return prefixTable;
    }

    /// <summary>
    /// Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The number of matches found.</returns>
    public static int Search(string pattern, string text)
    {
        var prefixTable = PrefixAnalysis(pattern);
        return Search(pattern, prefixTable, text);
    }

    /// <summary>
    /// Searches for the given pattern in the given text using the provided prefix table.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="prefixTable">The prefix table to use for the search.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The number of matches found.</returns>
    public static int Search(string pattern, int[] prefixTable, string text)
    {
        var amountOfMatches = 0;
        var positionInTerm = 0;
        var termLength = pattern.Length;

        foreach (var character in text)
        {
            // Move pattern in text until a match is found
            while (positionInTerm >= 0 && character != pattern[positionInTerm])
            {
                positionInTerm = prefixTable[positionInTerm];
            }

            positionInTerm++;

            // If the end of the pattern is reached a match is found
            if (positionInTerm == termLength)
            {
                amountOfMatches++;
                positionInTerm = prefixTable[positionInTerm]; // Continue searching for more matches
            }
        }

        return amountOfMatches;
    }
}