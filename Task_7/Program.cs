using Task_7;

var fileAnalyzer = new FileAnalyzer(@"D:\C#\Task_7\words_list.txt", new List<string>());
fileAnalyzer.ReadFile();
bool close = false;
while (!close)
{
    string? userInput = Console.ReadLine();
    var words = userInput.Split(' ', '.', ',', '!', '?', ':', ';', '—');
    var wordsList = new List<string>();
    foreach (var word in words)
    {
        wordsList.Add(word);
    }

    FixPunctuation(wordsList);
    var mistakes = fileAnalyzer.CheckForMistakes(wordsList);
    Console.WriteLine();
    fileAnalyzer.FindWords(mistakes);
    Console.Write("Do you wanna finish(Yes/No): ");
    if (Console.ReadLine() == "Yes")
        close = true;
}

void FixPunctuation(IList<string> data)
{
    for (var i = 0; i < data.Count; i++)
    {
        if (data.Contains(""))
        {
            data.Remove("");
        }
    }
}