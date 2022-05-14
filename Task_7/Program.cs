using Task_7;

var fileAnalyzer = new FileAnalyzer(@"D:\C#\Task_7\words_list.txt", new List<string>());
fileAnalyzer.ReadFile();
string? userInput = Console.ReadLine();
var words = userInput.Split(" ");

var wordsList = new List<string>();
foreach (var word in words) { wordsList.Add(word); }

FixPunctuation(wordsList);
fileAnalyzer.CheckForMistakes(wordsList);

void FixPunctuation(List<string> data)
{
    for (var i = 0; i < data.Count; i++)
    {
        var word = data[i];
        if (word.Contains(',') || word.Contains('.') || word.Contains('!') || word.Contains('?'))
        {
            var wordWithoutPunctuation = word.Substring(0, word.Length - 1);
            data[i] = wordWithoutPunctuation;
        }
    }

    for (var i = 0; i < data.Count; i++)
    {
        if (data.Contains(""))
        {
            data.Remove("");
        }
    }
}

Console.WriteLine(Levenshtein("crate", "flat"));

int Levenshtein(string a, string b)
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

    for (int i = 1; i <= firstWordLength; i++)
    {
        for (int j = 1; j <= secondWordLength; j++)
        {
            var constAdd = 1;
            if (b[j - 1] == a[i - 1])
            {
                constAdd = 0;
            }
            matrix[i, j] = Math.Min(
                Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                matrix[i - 1, j - 1] + constAdd);
        }
    }
    return matrix[firstWordLength, secondWordLength];
}
