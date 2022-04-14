namespace _6LetterWordChallenge;

public class FileWriter
{
    private string _path;

    public FileWriter(string path = "output.txt")
    {
        _path = path;
    }

    public void ListToFile(List<string> list)
    {
        File.WriteAllLines(_path, list.ToArray());
    }
}
