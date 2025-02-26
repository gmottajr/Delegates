namespace DelegatesStudyingConsoleApp.Classes;

public class FileSearch
{
    public delegate void SearchDelegate(string directorySearch);
    public SearchDelegate SendData { get; set; }

    public void Search(string directorySearch)
    {
        try
        {
            foreach (var dir in Directory.GetDirectories(directorySearch))
            {
                foreach (var aFile in Directory.GetFiles(dir))
                {
                    SendData(aFile);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}