namespace DelegatesStudyingConsoleApp.Classes;

public class FileSearch
{
    public delegate void FileFoundHandler(string fileName);
    public delegate void SearchErrorHandler(string errorMessage);
    public event FileFoundHandler FileFound;
    public event SearchErrorHandler SearchFailed;

    public void Search(string directorySearch)
    {
        if (string.IsNullOrEmpty(directorySearch) || !Directory.Exists(directorySearch))
        {
            string error = $"Invalid directory: {directorySearch}";
            Console.WriteLine(error);
            SearchFailed?.Invoke(error);
            return;
        }

        try
        {
            ProcessDirectory(directorySearch);
        }
        catch (Exception e)
        {
            string error = $"Error during search: {e.Message}";
            Console.WriteLine(error);
            SearchFailed?.Invoke(error);
        }
    }

    private void ProcessDirectory(string dir)
    {
        foreach (var aFile in Directory.GetFiles(dir))
        {
            FileFound?.Invoke(aFile);
        }
        foreach (var subDir in Directory.GetDirectories(dir))
        {
            ProcessDirectory(subDir);
        }
    }
}