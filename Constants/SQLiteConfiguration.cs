namespace SongManager.Desktop.Constants;

public static class SQLiteConfiguration
{
    private const string DatabaseName = "SongManagerDesktop.db3";
    public static string DBPath => Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
}
