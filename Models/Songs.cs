using SongManager.Desktop.Enum;
using SQLite;

namespace SongManager.Desktop.Models;
[SQLiteEntity]
public class Songs : BaseEntity<long>
{
    [Indexed(Name = "idx_songname_songauthor_singer_key", Order = 1, Unique = true)]
    public string SongName { get; set; } = string.Empty;
    [Indexed(Name = "idx_songname_songauthor_singer_key", Order = 2, Unique = true)]
    public string SongAuthor { get; set; } = string.Empty;
    [Indexed(Name = "idx_songname_songauthor_singer_key", Order = 3, Unique = true)]
    public string Singer { get; set; } = string.Empty;
    [Indexed(Name = "idx_songname_songauthor_singer_key", Order = 4, Unique = true)]
    public Key KeySignature { get; set; } = Key.NA;
    public string Comment { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    [Ignore]    
    public SongsDto SongDto => this.Map<SongsDto>();
}
