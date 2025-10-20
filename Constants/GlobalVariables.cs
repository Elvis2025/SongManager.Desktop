using SongManager.Desktop.Enum;

namespace SongManager.Desktop.Constants;

public abstract class GlobalVariables
{
    public static readonly string Attributes = "SongManager.Desktop.Attributes";

    public static readonly VocalRangeDto[] VocalRanges = 
        [
            new VocalRangeDto 
            { 
                Id = 1,
                VocalRange = VocalRange.Soprano,
                Gender = Gender.Female
            },
            new VocalRangeDto 
            { 
                Id = 2,
                VocalRange = VocalRange.Mezzo_Soprano,
                Gender = Gender.Female
            },
            new VocalRangeDto 
            { 
                Id = 3,
                VocalRange = VocalRange.Contralto,
                Gender = Gender.Female
            },
            new VocalRangeDto 
            { 
                Id = 4,
                VocalRange = VocalRange.Tenor,
                Gender = Gender.Male
            },
            new VocalRangeDto 
            { 
                Id = 5,
                VocalRange = VocalRange.Barítono,
                Gender = Gender.Male
            },
            new VocalRangeDto 
            { 
                Id = 6,
                VocalRange = VocalRange.Bajo,
                Gender = Gender.Male
            },

        ];
    public static readonly GenderDto[] Genres = 
        [
            new GenderDto 
            {
                Id = 1,
                Gender = Gender.Male
            },
            new GenderDto 
            {
                Id = 2,
                Gender = Gender.Female
            },

        ];

    public static readonly string SingerId = "SingerId";
    public static readonly string SongId = "SongId";
}
