using SQLiteNetExtensions.Attributes;

namespace SongManager.Desktop.Models;
[SQLiteEntity]
public class KeysSongs : BaseEntity<long>
{
    [ForeignKey(typeof(Songs))] 
    public long SongId { get; set; }
    public string Key { get; set; } = string.Empty;

}
