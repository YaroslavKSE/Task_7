using Task_7;

var fileAnalyzer = new FileAnalyzer(@"D:\C#\Task_7\words_list.txt", new List<string>());
fileAnalyzer.ReadFile();
string? userInput = Console.ReadLine();
var wordsList = userInput.Split(" ");
FixPunctuation(wordsList);
fileAnalyzer.CheckForMistakes(wordsList);

void FixPunctuation(IList<string> data)
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
}

