using SongManager.Desktop.Repositories.SQLite;

namespace SongManager.Desktop.UsesCases;


public static class TestData
{
    //private static readonly ISQLiteManager managerSQLite = SongManagerApp.CreateInstance<ISQLiteManager>();

    public static void InsertTestDataAsync()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.WhenAll(
                InsertSongsListAsync()
            );
        });
    }
    public static async Task InsertSongsListAsync()
    {
        var songListRepository = SongManagerApp.CreateInstance<IRepository<Models.SongsLists>>();
        await songListRepository.DeleteAllAsync();
        await songListRepository.InsertAllAsync(new List<Models.SongsLists>
        {
            new Models.SongsLists
            {
                SongName = "Song 1",
                SongAuthor = "Author 1",
                Singer = "Singer 1",
                KeySignature = Enum.Key.C,
                Link = "http://example.com/song1",
            },
            new Models.SongsLists
            {
                SongName = "Song 2",
                SongAuthor = "Author 2",
                Singer = "Singer 2",
                KeySignature = Enum.Key.G,
                Link = "http://example.com/song2",
            }
        });
    }


}


