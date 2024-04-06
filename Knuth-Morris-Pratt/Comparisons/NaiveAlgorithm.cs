namespace Knuth_Morris_Pratt.Comparisons;

/// <summary>
/// This class implements a naive text search algorithm.
/// </summary>
public static class NaiveAlgorithm
{
    /// <summary>
    /// Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The number of matches found.</returns>
    public static int Search(string pattern, string text)
    {
        var amountOfMatches = 0;

        for (var i = 0; i <= text.Length - pattern.Length; i++)
        {
            var found = !pattern.Where((t, j) => text[i + j] != t).Any();

            if (found)
            {
                amountOfMatches++;
            }
        }

        return amountOfMatches;
    }
}