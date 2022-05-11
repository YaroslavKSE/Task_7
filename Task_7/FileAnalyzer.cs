using System.Net;

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
}