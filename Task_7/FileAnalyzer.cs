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
        Console.Write("Looks like you have typos in next words: ");
        foreach (var word in wordsList)
        {
            if (!_data.Contains(word))
            {
                Console.Write($"'{word}' ");
            }
        }
    }

    public int longestSubsequence(string first, string sec)
    {
        int[,] table = new int[first.Length + 2, sec.Length + 2];
        table[0, 0] = 0;
        for (int i = 0; i < sec.Length + 1; i++)
        {
            table[1, i] = 0;
        }
        for (int i = 0; i < first.Length + 1; i++)
        {
            table[i, 1] = 0;
        }


        return 0;
    }
}