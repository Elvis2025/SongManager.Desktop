using SQLiteNetExtensions.Attributes;

namespace SongManager.Desktop.Models;
[SQLiteEntity]
public class Songs : BaseEntity<long>
{
    [Indexed(Name = "idx_songname_songauthor_singerId", Order = 1, Unique = true)]
    public string SongName { get; set; } = string.Empty;

    [Indexed(Name = "idx_songname_songauthor_singerId", Order = 2, Unique = true)]
    public string SongAuthor { get; set; } = string.Empty;

    [Indexed(Name = "idx_songname_songauthor_singerId", Order = 3, Unique = true)]
    [ForeignKey(typeof(Singers))]
    public long SingerId { get; set; } = new();

    public string Comment { get; set; } = string.Empty;

    public string Link { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;

    [Ignore]    
    public SongsDto SongDto => this.Map<SongsDto>();
}
