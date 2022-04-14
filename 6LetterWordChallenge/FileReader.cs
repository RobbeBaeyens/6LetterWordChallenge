namespace _6LetterWordChallenge;

public class FileReader
{
    private string _path;

    public FileReader(string path = "input.txt")
    {
        _path = path;
    }

    public List<string> FileToList()
    {
        var dictionary = new Dictionary<int, string>();
        return  File.ReadAllLines(_path).ToList();
    }
}
