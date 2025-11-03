namespace SongManager.Desktop.Extensions;

public static class ObsevableCollectionExtensions
{
    public static ObservableCollection<SongsDto> FormatterSongsRows(this ObservableCollection<SongsDto> songs)
    {
        foreach (var (song, i) in songs.Select((value, i) => (value, i)))
        {
            if ((i % 2) == 0)
            {
                song.HexColor = Color.FromArgb("#FFFFFF");
                continue;
            }
            song.HexColor = Color.FromArgb("#E1E1E1");
        }
        return songs;
    }
}
