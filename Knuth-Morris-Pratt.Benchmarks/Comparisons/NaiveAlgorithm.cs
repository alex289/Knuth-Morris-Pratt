namespace Knuth_Morris_Pratt.Benchmarks.Comparisons;

public static class NaiveAlgorithm
{
    public static int Search(string pattern, string text)
    {
        var amountOfMatches = 0;

        for (var i = 0; i <= text.Length - pattern.Length; i++)
        {
            var found = true;

            for (var j = 0; j < pattern.Length; j++)
            {
                if (text[i + j] != pattern[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
            {
                amountOfMatches++;
            }
        }

        return amountOfMatches;
    }
}