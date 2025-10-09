using SQLite;

namespace SongManager.Desktop.Repositories.SQLite;

public interface ISQLiteManager
{
    ISQLiteAsyncConnection Connection { get; }

    Task CreateTables();
    void CreateTablesUnAsync();
}
