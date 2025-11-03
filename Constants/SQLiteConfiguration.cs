namespace SongManager.Desktop.Constants;

public static class SQLiteConfiguration
{
    private const string DatabaseName = "SongManagerDesktop.db3";
    private const string FilePath = @"C:\Song Manager\Produccion";
    private const string FilePathDev = @"C:\Song Manager\Develop";
    private const string FilePathBackUp = @"C:\Song Manager\Backup";
    public static string DBPath => Path.Combine(FilePath, DatabaseName);
    public static string DBPathDev => Path.Combine(FilePathDev, DatabaseName);
}
