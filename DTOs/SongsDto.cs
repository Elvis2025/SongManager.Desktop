namespace SongManager.Desktop.DTOs;
[AutoMap(typeof(Songs))]
public sealed record class SongsDto : BaseDto<long>
{
    public string SongName { get; set; } = string.Empty;
    public string SongAuthor { get; set; } = string.Empty;
    public string Singer { get; set; } = string.Empty;
    public Key KeySignature { get; set; } = Key.NA;
    public string KeySignatureValue => KeySignature.ToString();
    public string Comment { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public Songs Songs => this.Map<Songs>();
    public Color? HexColor { get; set; }
}
