namespace Knuth_Morris_Pratt.Comparisons;

/// <summary>
///     This class implements the Boyer-Moore text search algorithm.
/// </summary>
public static class BoyerMooreAlgorithm
{
    private static bool IsPrefix(string needle, int position)
    {
        for (int i = position, j = 0; i < needle.Length; ++i, ++j)
        {
            if (needle[i] != needle[j])
            {
                return false;
            }
        }

        return true;
    }

    private static int SuffixSize(string needle, int position)
    {
        int size = 0, i = position, j = needle.Length - 1;

        while (i >= 0 && needle[i] == needle[j])
        {
            --i;
            --j;
            ++size;
        }

        return size;
    }

    private static List<int> MakeCharTable(string needle)
    {
        var table = new List<int>(char.MaxValue);

        for (int i = 0; i < char.MaxValue; i++)
        {
            table.Add(needle.Length);
        }

        for (int i = 0; i < needle.Length - 1; ++i)
        {
            table[needle[i]] = needle.Length - 1 - i;
        }

        return table;
    }

    private static List<int> MakeOffsetTable(string needle)
    {
        var table = new List<int>(needle.Length);
        int lastPrefixPosition = needle.Length;

        for (int i = needle.Length; i > 0; --i)
        {
            if (IsPrefix(needle, i))
            {
                lastPrefixPosition = i;
            }

            table.Add(lastPrefixPosition - i + needle.Length);
        }

        for (int i = 0; i < needle.Length - 1; ++i)
        {
            int size = SuffixSize(needle, i);
            table[size] = needle.Length - 1 - i + size;
        }

        return table;
    }

    /// <summary>
    ///     Searches for the given pattern in the given text.
    /// </summary>
    /// <param name="text">The text to search in.</param>
    /// <param name="pattern">The pattern to search for.</param>
    /// <returns>The index of the found pattern (-1 if not found).</returns>
    public static int Search(string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            return 0;
        }

        List<int> charTable = MakeCharTable(pattern);
        List<int> offsetTable = MakeOffsetTable(pattern);

        for (int i = pattern.Length - 1, j; i < text.Length;)
        {
            for (j = pattern.Length - 1; pattern[j] == text[i]; --i, --j)
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
}