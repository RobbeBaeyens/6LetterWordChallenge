using _6LetterWordChallenge;

// Settings
var maxWordSize = 6;
var inputSource = "input.txt";
var outputSource = "output.txt";

// Get input file as a list
FileReader fileReader = new(inputSource);
FileWriter fileWriter = new(outputSource);
var input = fileReader.FileToList();

// Get 6 letter words
var wordsToFind = input.Where(x => x.Length == 6);
wordsToFind = wordsToFind.Distinct().ToList();

// Create List for inputs, excluding 6 letter words
var lines = input.ToList();
foreach (var word in wordsToFind)
{
    lines.Remove(word);
}

// Create solution list
List<string> allCombinations = new List<string>();

// Setup Console
var i = 0.00;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.CursorVisible = false;
Console.WriteLine("====================");
Console.WriteLine("|\t\t   |");
Console.WriteLine("|\t\t   |");
Console.WriteLine("|\t\t   |");
Console.WriteLine("====================");

// Get combinations for every 6 letter word
foreach (var word in wordsToFind)
{
    InputCombiner inputCombiner = new InputCombiner(lines, word, maxWordSize);
    allCombinations.AddRange(inputCombiner.GetCombinations());
    allCombinations.Add("\n");
    // Display progression
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"\n\n|\t{Math.Ceiling(i / wordsToFind.ToList().Count * 100.00)}%\n");
    i++;
}

// Write combinations to output file
fileWriter.ListToFile(allCombinations.ToList());

// Display Done
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\tDone");
Console.ForegroundColor = ConsoleColor.White;

// List all combinations in console
fileReader = new(outputSource);
Console.SetCursorPosition(5, 0);
Console.BufferHeight = fileReader.FileToList().Count + 20;
Console.BufferWidth = 5000;
var cursorPosX = 6;
var cursorPosY = 0;
var whitespaces = 0;
foreach (var line in fileReader.FileToList())
{
    cursorPosX++;
    if (whitespaces > 5)
    {
        whitespaces = 0;
        cursorPosX = 7;
        cursorPosY += 24;
    }
    Console.SetCursorPosition(cursorPosY, cursorPosX);
    Console.WriteLine(line);
    if (string.IsNullOrEmpty(line))
        whitespaces++;
}