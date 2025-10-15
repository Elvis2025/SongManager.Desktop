using SongManager.Desktop.Attributes;
using SongManager.Desktop.Enum;
using SongManager.Desktop.Extensions;
using SongManager.Desktop.Models;

namespace SongManager.Desktop.DTOs;

[AutoMap(typeof(Singers))]
public record class SingersDto : BaseDto<long>
{
    public string FullName => $"{FirstName} {FirstSurname}";
    public string Code => (FirstName.Length > 0 && FirstSurname.Length > 0 ? 
                           $"{FirstName[0]}{FirstSurname[0]}-{Id}" : "");
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string FirstSurname { get; set; } = string.Empty;
    public string SecondSurname { get; set; } = string.Empty;
    public string Gender => GenderId.ToString();
    public string VocalRange => (int)VocalRangeId >= 0 ? VocalRangeId.ToString(): string.Empty;
    public Gender GenderId { get; set; }
    public VocalRange VocalRangeId { get; set; }
    public Singers Singer => this.Map<Singers>();

}
