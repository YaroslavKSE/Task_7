using System.Data;

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

    public void CheckForMistakes(IList<string> wordsList)
    {
        Console.WriteLine("Looks like you have typos in next words: ");
        foreach (var word in wordsList)
        {
            if (!_data.Contains(word))
            {
                Console.WriteLine($"'{word}' ");
                Console.Write("Possible replacements: ");
                FindFiveSimilarWords(word);
                Console.WriteLine();
            }
        }
    }

    public void FindFiveSimilarWords(string word)
    {
        List<string> dataCopy = _data;
        for (int i = 0; i < 5; i++)
        {
            int longestSub = 0;
            string wordToSuggest = "";
            foreach (var dictWord in dataCopy)
            {
                if (longestSubsequence(word, dictWord) > longestSub)
                {
                    wordToSuggest = dictWord;
                    longestSub = longestSubsequence(word, dictWord);
                }
            }
            Console.Write(wordToSuggest + " ");
            dataCopy.Remove(wordToSuggest);
        }
    }

    public int longestSubsequence(string first, string sec)
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
}