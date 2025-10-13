using SongManager.Desktop.Attributes;
using SongManager.Desktop.Enum;
using SongManager.Desktop.Extensions;
using SongManager.Desktop.Models;

namespace SongManager.Desktop.DTOs;
[AutoMap(typeof(SongsList))]
public record class SongsListDto : BaseDto<long>
{
    public string SongName { get; set; } = string.Empty;
    public string SongAuthor { get; set; } = string.Empty;
    public string Singer { get; set; } = string.Empty;
    public Key KeySignature { get; set; } = Key.NA;
    public string KeySignatureValue => KeySignature.ToString();
    public string Link { get; set; } = string.Empty;
    public SongsList SongsList => this.Map<SongsList>();
}
