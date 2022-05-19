namespace Task_7;

public class LongestCommonSubsequence
{
    private List<string> _words;

    public LongestCommonSubsequence(List<string> words)
    {
        _words = words;
    }
    public int FindCommonSub(string a, string b)
    {
        var firstWordLength = a.Length;
        var secondWordLength = b.Length;
        var matrix = new int[firstWordLength, secondWordLength];
        for (int i = 0; i < firstWordLength; i++)
        {
            for (int j = 0; j < secondWordLength; j++)
            {
                if (a[i] != b[j])
                {
                    if (i - 1 != -1 && j - 1 != -1)
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }

                    if (i - 1 == -1)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }

                    if (j - 1 == -1)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                
                }
                else
                {
                    if(i - 1 != -1 && j - 1 != -1)
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        return matrix[firstWordLength - 1, secondWordLength - 1];
    }
}