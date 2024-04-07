namespace Knuth_Morris_Pratt.Comparisons;

/// <summary>
///     This class implements the Boyer-Moore text search algorithm.
/// </summary>
public static class BoyerMooreAlgorithm
{
    /// <summary>
    ///     Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="text">The text to search in.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            return -1;
        }

        var charTable = MakeCharTable(pattern);
        var offsetTable = MakeOffsetTable(pattern);

        for (int i = pattern.Length - 1, j; i < text.Length;)
        {
            for (j = pattern.Length - 1; pattern[j] == text[i]; i--, j--)
            {
                if (j == 0)
                {
                    return i;
                }
            }

            i += Math.Max(offsetTable[pattern.Length - 1 - j], charTable[text[i]]);
        }

        return -1;
    }

    /// <summary>
    ///     Makes the jump table based on the mismatched character information.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <returns>The jump table.</returns>
    private static IList<int> MakeCharTable(string pattern)
    {
        const int alphabetSize = 256;
        var table = new int[alphabetSize];

        for (var i = 0; i < table.Length; ++i)
        {
            table[i] = pattern.Length;
        }

        for (var i = 0; i < pattern.Length; ++i)
        {
            table[pattern[i]] = pattern.Length - 1 - i;
        }

        return table;
    }

    /// <summary>
    ///     Makes the jump table based on the mismatched character information.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <returns>The jump table.</returns>
    private static IList<int> MakeOffsetTable(string pattern)
    {
        var table = new int[pattern.Length];
        var lastPrefixPosition = pattern.Length;

        for (var i = pattern.Length; i > 0; i--)
        {
            if (IsPrefix(pattern, i))
            {
                lastPrefixPosition = i;
            }

            table[pattern.Length - i] = lastPrefixPosition - i + pattern.Length;
        }

        for (var i = 0; i < pattern.Length - 1; ++i)
        {
            var suffixLength = SuffixLength(pattern, i);
            table[suffixLength] = pattern.Length - 1 - i + suffixLength;
        }

        return table;
    }

    /// <summary>
    ///     Returns true if the pattern is a prefix of the string ending at the given position.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="p">The position to end the suffix at.</param>
    /// <returns>True if the pattern is a prefix of the string ending at the given position.</returns>
    private static bool IsPrefix(string pattern, int p)
    {
        for (int i = p, j = 0; i < pattern.Length; ++i, ++j)
        {
            if (pattern[i] != pattern[j])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Returns the length of the suffix of the pattern ending at the given position.
    /// </summary>
    /// <param name="pattern">The pattern to search for.</param>
    /// <param name="p">The position to end the suffix at.</param>
    /// <returns>The length of the suffix.</returns>
    private static int SuffixLength(string pattern, int p)
    {
        var length = 0;

        for (int i = p, j = pattern.Length - 1; i >= 0 && pattern[i] == pattern[j]; --i, --j)
        {
            length += 1;
        }

        return length;
    }
}