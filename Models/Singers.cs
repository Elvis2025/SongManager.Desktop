namespace SongManager.Desktop.Models;
[SQLiteEntity]
public class Singers : BaseEntity<long>
{
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string FirstSurname { get; set; } = string.Empty;
    public string SecondSurname { get; set; } = string.Empty;
    public Gender GenderId { get; set; }
    public VocalRange VocalRangeId { get; set; }
}
