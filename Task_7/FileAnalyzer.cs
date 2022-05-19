namespace Task_7;

public class FileAnalyzer
{
    private readonly string _path;
    private readonly List<string> _data;

    public FileAnalyzer(string path, List<string> data)
    {
        _path = path;
        _data = data;
    }

    public void ReadFile()
    {
        foreach (var line in File.ReadAllLines(_path))
        {
            _data.Add(line);
        }
    }

    public List<string> CheckForMistakes(IList<string> wordsList)
    {
        var mistakesInWords = new List<string>();
        Console.Write("Looks like you have typos in next words: ");
        foreach (var word in wordsList)
        {
            if (!_data.Contains(word))
            {
                Console.Write($"'{word}' ");
                mistakesInWords.Add(word);
            }
        }

        return mistakesInWords;
    }

    public List<string> FindWords(List<string> wordsList)
    {
        var possibleWords = new List<string>();
        foreach (var word in wordsList)
        {
            var counter = 0;
            foreach (var secondWord in _data)
            {
                var subLength = FindCommonSub(word, secondWord);
                var LevLength = Levenshtein(word, secondWord);
                if (subLength == word.Length - 1 && LevLength <= 2)
                {
                    possibleWords.Add(secondWord);
                    counter++;
                }

                if (counter == 5)
                {
                    break;
                }
            }
        }

        Console.WriteLine("Maybe you meant:");
        foreach (var word in possibleWords)
        {
            Console.Write($"'{word}' ");
        }

        Console.WriteLine();

        return possibleWords;
    }

    private int FindCommonSub(string first, string sec)
    {
        string[,] table = new string[first.Length + 2, sec.Length + 2];
        table[1, 1] = "0";
        for (int i = 2, y = 0; i <= first.Length + 1; i++, y++)
        {
            table[i, 0] = first[y].ToString();
            table[i, 1] = "0";
        }

        for (int i = 2, y = 0; i <= sec.Length + 1; i++, y++)
        {
            table[0, i] = sec[y].ToString();
            table[1, i] = "0";
        }

        for (int i = 2; i <= first.Length + 1; i++)
        {
            string firstElement = table[i, 0];
            for (int y = 2; y <= sec.Length + 1; y++)
            {
                string secElement = table[0, y];
                if (firstElement == secElement)
                {
                    table[i, y] = (Int32.Parse(table[i - 1, y - 1]) + 1).ToString();
                }
                else
                {
                    if (Int32.Parse(table[i, y - 1]) > Int32.Parse(table[i - 1, y]))
                    {
                        table[i, y] = table[i, y - 1];
                    }
                    else
                    {
                        table[i, y] = table[i - 1, y];
                    }
                }
            }
        }

        return Int32.Parse(table[first.Length + 1, sec.Length + 1]);
    }

    private int Levenshtein(string a, string b)
    {
        var firstWordLength = a.Length;
        var secondWordLength = b.Length;
        var matrix = new int[firstWordLength + 1, secondWordLength + 1];
        if (firstWordLength == 0)
        {
            return secondWordLength;
        }

        if (secondWordLength == 0)
        {
            return firstWordLength;
        }

        for (var i = 0; i <= firstWordLength;)
        {
            matrix[i, 0] = i++;
        }

        for (var j = 0; j <= secondWordLength;)
        {
            matrix[0, j] = j++;
        }

        for (var i = 1; i <= firstWordLength; i++)
        {
            for (var j = 1; j <= secondWordLength; j++)
            {
                var constAdd = 1;
                if (b[j - 1] == a[i - 1])
                {
                    constAdd = 0;
                }

                matrix[i, j] = Math.Min(
                    Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + constAdd);
                // if (a[i] == b[j - 1] && a[i - 1] == b[j])
                // {
                //     matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1);
                // }
            }
        }

        return matrix[firstWordLength, secondWordLength];
    }
}