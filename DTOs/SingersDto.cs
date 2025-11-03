namespace SongManager.Desktop.DTOs;

[AutoMap(typeof(Singers))]
public record class SingersDto : BaseDto<long>
{
    public string FullName => $"{FirstName} {FirstSurname}";
    public string FullNameComplete => $"{FirstName} {SecondName} {FirstSurname} {SecondSurname}";
    public string Code => (FirstName.Length > 0 && FirstSurname.Length > 0 ? 
                           $"{FirstName[0]}{FirstSurname[0]}-{Id}" : "");
    public string FirstName { get; set; } = string.Empty;

    public string SecondName { get; set; } = string.Empty;
    public string FirstSurname { get; set; } = string.Empty;
    public string SecondSurname { get; set; } = string.Empty;
    public string Gender => GenderId.ToString();
    public string VocalRange => (VocalRangeId.ToString().Contains('_') ? 
                                    VocalRangeId.ToString().Replace('_', ' ') : VocalRangeId.ToString());
    public Gender GenderId { get; set; }
    public VocalRange VocalRangeId { get; set; } = Enum.VocalRange.None;
    public Singers Singer => this.Map<Singers>();

    public Color? HexColor { get; set; }
}
