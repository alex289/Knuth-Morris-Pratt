namespace Knuth_Morris_Pratt;

public sealed class TextSearchAlgorithm
{
    public int[] PrefixAnalysis(string pattern)
    {
        var prefixLength = -1;
        var prefixTable = new int[pattern.Length + 1];

        prefixTable[0] = prefixLength;

        for (var i = 0; i <= pattern.Length - 1; i++)
        {
            while (prefixLength >= 0 && pattern[prefixLength] != pattern[i])
            {
                prefixLength = prefixTable[prefixLength];
            }

            prefixLength++;
            prefixTable[i + 1] = prefixLength;
        }

        return prefixTable;
    }

    public int Search(string pattern, string text)
    {
        var prefixTable = PrefixAnalysis(pattern);
        return Search(pattern, prefixTable, text);
    }

    public int Search(string pattern, int[] prefixTable, string text)
    {
        var amountOfMatches = 0;
        var positionInTerm = 0;
        var termLength = pattern.Length;

        foreach (var character in text)
        {
            while (positionInTerm >= 0 && character != pattern[positionInTerm])
            {
                positionInTerm = prefixTable[positionInTerm];
            }

            positionInTerm++;

            if (positionInTerm == termLength)
            {
                amountOfMatches++;
                positionInTerm = prefixTable[positionInTerm];
            }
        }

        return amountOfMatches;
    }
}