using Task_7;

var data = new List<string>();

foreach (var line in File.ReadAllLines(@"D:\C#\Task_7\words_list.txt"))
{
    data.Add(line);
}

var fileAnalyzer = new FileAnalyzer(data);
var separators = " .,!?:;-";
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
    Console.Write("Looks like you have typos in next words: ");
    foreach (var word in mistakes)
    {
        Console.Write($"'{word}' ");
    }

    Console.WriteLine();
    var result = fileAnalyzer.FindWords(mistakes);
    Console.WriteLine("Maybe you meant:");
    foreach (var word in result)
    {
        Console.Write($"'{word}' ");
    }

    Console.WriteLine();
    Console.Write("Do you wanna finish(Yes/No): ");
    if (Console.ReadLine() == "Yes")
        close = true;
}

void FixPunctuation(IList<string> data)
{
    for (var i = 0; i < data.Count; i++)
    {
        foreach (var separator in separators)
        {
            if (data.Contains(separator.ToString()))
            {
                data.Remove(separator.ToString());
            }

            if (data.Contains(""))
            {
                data.Remove("");
            }
        }
    }
}


// int Levenshtein(string a, string b)
// {
//     var firstWordLength = a.Length;
//     var secondWordLength = b.Length;
//     var matrix = new int[firstWordLength + 1, secondWordLength + 1];
//     if (firstWordLength == 0)
//     {
//         return secondWordLength;
//     }
//
//     if (secondWordLength == 0)
//     {
//         return firstWordLength;
//     }
//
//     for (var i = -1; i <= firstWordLength + 1;)
//     {
//         matrix[i, -1] = i++;
//     }
//
//     for (var j = -1; j <= secondWordLength + 1;)
//     {
//         matrix[-1, j] = j++;
//     }
//
//     for (var i = 1; i <= firstWordLength; i++)
//     {
//         for (var j = 1; j <= secondWordLength; j++)
//         {
//             var constAdd = 1;
//             if (b[j - 1] == a[i - 1])
//             {
//                 constAdd = 0;
//             }
//
//             matrix[i, j] = Math.Min(
//                 Math.Min(matrix[i - 1, j] + 1, //deletion
//                     matrix[i, j - 1] + 1), //insertion
//                 matrix[i - 1, j - 1] + constAdd); // substitution
//             if (a[i] == b[j - 1] && a[i - 1] == b[j])
//             {
//                 matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1);
//             }
//         }
//     }
//
//     return matrix[firstWordLength - 1, secondWordLength - 1];
// }