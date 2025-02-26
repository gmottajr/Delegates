namespace DelegatesStudyingConsoleApp.Classes;

public class FileSearch
{
    public delegate void FileFoundHandler(string fileName);
    public event FileFoundHandler FileFound;

    public void Search(string directorySearch)
    {
        try
        {
            foreach (var dir in Directory.GetDirectories(directorySearch))
            {
                foreach (var aFile in Directory.GetFiles(dir))
                {
                    FileFound?.Invoke(aFile);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during search: {e.Message}");
        }
    }
}