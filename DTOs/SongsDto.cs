namespace SongManager.Desktop.DTOs;
[AutoMap(typeof(Songs))]
public sealed record class SongsDto : BaseDto<long>
{
    public string SongName { get; set; } = string.Empty;
    public string SongAuthor { get; set; } = string.Empty;
    public long SingerId { get; set; } 
    public string SingerName { get; set; } = string.Empty;
    public string CreatorUserName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public Songs Songs => this.Map<Songs>();
    public Color? HexColor { get; set; }

    public List<KeyDto> Keys => Key.ToKeyList();
}
