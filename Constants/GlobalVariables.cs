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
    public static readonly KeyDto[] Keys = 
        [
            #region Major Keys
            new KeyDto { Id = 1,  Key = Key.C },
            new KeyDto { Id = 2,  Key = Key.C_Sharp },
            new KeyDto { Id = 3,  Key = Key.C_Double_Sharp },
            new KeyDto { Id = 4,  Key = Key.C_Flat },
            new KeyDto { Id = 5,  Key = Key.C_Double_Flat },

            new KeyDto { Id = 6,  Key = Key.D },
            new KeyDto { Id = 7,  Key = Key.D_Flat },
            new KeyDto { Id = 8,  Key = Key.D_Sharp },
            new KeyDto { Id = 9,  Key = Key.D_Double_Sharp },
            new KeyDto { Id = 10, Key = Key.D_Double_Flat },

            new KeyDto { Id = 11, Key = Key.E },
            new KeyDto { Id = 12, Key = Key.E_Flat },
            new KeyDto { Id = 13, Key = Key.E_Sharp },
            new KeyDto { Id = 14, Key = Key.E_Double_Sharp },
            new KeyDto { Id = 15, Key = Key.E_Double_Flat },

            new KeyDto { Id = 16, Key = Key.F },
            new KeyDto { Id = 17, Key = Key.F_Flat },
            new KeyDto { Id = 18, Key = Key.F_Sharp },
            new KeyDto { Id = 19, Key = Key.F_Double_Sharp },
            new KeyDto { Id = 20, Key = Key.F_Double_Flat },

            new KeyDto { Id = 21, Key = Key.G },
            new KeyDto { Id = 22, Key = Key.G_Flat },
            new KeyDto { Id = 23, Key = Key.G_Sharp },
            new KeyDto { Id = 24, Key = Key.G_Double_Flat },
            new KeyDto { Id = 25, Key = Key.G_Double_Sharp },

            new KeyDto { Id = 26, Key = Key.A },
            new KeyDto { Id = 27, Key = Key.A_Flat },
            new KeyDto { Id = 28, Key = Key.A_Sharp },
            new KeyDto { Id = 29, Key = Key.A_Double_Flat },
            new KeyDto { Id = 30, Key = Key.A_Double_Sharp },

            new KeyDto { Id = 31, Key = Key.B },
            new KeyDto { Id = 32, Key = Key.B_Flat },
            new KeyDto { Id = 33, Key = Key.B_Sharp },
            new KeyDto { Id = 34, Key = Key.B_Double_Flat },
            new KeyDto { Id = 35, Key = Key.B_Double_Sharp },

        #endregion

            #region Minor Keys
            new KeyDto { Id = 36, Key = Key.C_Minor },
            new KeyDto { Id = 37, Key = Key.C_Sharp_Minor },
            new KeyDto { Id = 38, Key = Key.C_Double_Sharp_Minor },
            new KeyDto { Id = 39, Key = Key.C_Flat_Minor },
            new KeyDto { Id = 40, Key = Key.C_Double_Flat_Minor },

            new KeyDto { Id = 41, Key = Key.D_Minor },
            new KeyDto { Id = 42, Key = Key.D_Sharp_Minor },
            new KeyDto { Id = 43, Key = Key.D_Double_Sharp_Minor },
            new KeyDto { Id = 44, Key = Key.D_Flat_Minor },
            new KeyDto { Id = 45, Key = Key.D_Double_Flat_Minor },

            new KeyDto { Id = 46, Key = Key.E_Minor },
            new KeyDto { Id = 47, Key = Key.E_Sharp_Minor },
            new KeyDto { Id = 48, Key = Key.E_Double_Sharp_Minor },
            new KeyDto { Id = 49, Key = Key.E_Flat_Minor },
            new KeyDto { Id = 50, Key = Key.E_Double_Flat_Minor },

            new KeyDto { Id = 51, Key = Key.F_Minor },
            new KeyDto { Id = 52, Key = Key.F_Sharp_Minor },
            new KeyDto { Id = 53, Key = Key.F_Double_Sharp_Minor },
            new KeyDto { Id = 54, Key = Key.F_Flat_Minor },
            new KeyDto { Id = 55, Key = Key.F_Double_Flat_Minor },

            new KeyDto { Id = 56, Key = Key.G_Minor },
            new KeyDto { Id = 57, Key = Key.G_Sharp_Minor },
            new KeyDto { Id = 58, Key = Key.G_Double_Sharp_Minor },
            new KeyDto { Id = 59, Key = Key.G_Flat_Minor },
            new KeyDto { Id = 60, Key = Key.G_Double_Flat_Minor },

            new KeyDto { Id = 61, Key = Key.A_Minor },
            new KeyDto { Id = 62, Key = Key.A_Sharp_Minor },
            new KeyDto { Id = 63, Key = Key.A_Double_Sharp_Minor },
            new KeyDto { Id = 64, Key = Key.A_Flat_Minor },
            new KeyDto { Id = 65, Key = Key.A_Double_Flat_Minor },

            new KeyDto { Id = 66, Key = Key.B_Minor },
            new KeyDto { Id = 67, Key = Key.B_Sharp_Minor },
            new KeyDto { Id = 68, Key = Key.B_Double_Sharp_Minor },
            new KeyDto { Id = 69, Key = Key.B_Flat_Minor },
            new KeyDto { Id = 70, Key = Key.B_Double_Flat_Minor },
            #endregion
        ];

    public static readonly string SingerId = "SingerId";
    public static readonly string SongId = "SongId";
    public static readonly string UserId = "UserId";

    public static int GetSongId => Preferences.Get(SongId, -1);
    public static int GetUserId => Preferences.Get(UserId, -1);

}
