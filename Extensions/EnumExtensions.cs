namespace SongManager.Desktop.Extensions;

public static class EnumExtensions
{
    public static string GetKeyName(this Key keyString)
    {
        return keyString switch
        {
            #region Major Keys
            Key.C => "C",
            Key.C_Sharp => "C#",
            Key.C_Double_Sharp => "C##",
            Key.C_Flat => "Cb",
            Key.C_Double_Flat => "Cbb",
            Key.D => "D",
            Key.D_Sharp => "D#",
            Key.D_Double_Sharp => "D##",
            Key.D_Flat => "Db",
            Key.D_Double_Flat => "Dbb",
            Key.E => "E",
            Key.E_Sharp => "E#",
            Key.E_Double_Sharp => "E##",
            Key.E_Flat => "Eb",
            Key.E_Double_Flat => "Ebb",
            Key.F => "F",
            Key.F_Sharp => "F#",
            Key.F_Double_Sharp => "F##",
            Key.F_Flat => "Fb",
            Key.F_Double_Flat => "Fbb",
            Key.G => "G",
            Key.G_Sharp => "G#",
            Key.G_Double_Sharp => "G##",
            Key.G_Flat => "Gb",
            Key.G_Double_Flat => "Gbb",
            Key.A => "A",
            Key.A_Sharp => "A#",
            Key.A_Double_Sharp => "A##",
            Key.A_Flat => "Ab",
            Key.A_Double_Flat => "Abb",
            Key.B => "B",
            Key.B_Sharp => "B#",
            Key.B_Double_Sharp => "B##",
            Key.B_Flat => "Bb",
            Key.B_Double_Flat => "Bbb",
            #endregion
            
            #region Minor Keys
            Key.C_Minor => "Cm",
            Key.C_Sharp_Minor => "C#m",
            Key.C_Double_Sharp_Minor => "C##m",
            Key.C_Flat_Minor => "Cbm",
            Key.C_Double_Flat_Minor => "Cbbm",

            Key.D_Minor => "Dm",
            Key.D_Sharp_Minor => "D#m",
            Key.D_Double_Sharp_Minor => "D##m",
            Key.D_Flat_Minor => "Dbm",
            Key.D_Double_Flat_Minor => "Dbbm",

            Key.E_Minor => "Em",
            Key.E_Sharp_Minor => "E#m",
            Key.E_Double_Sharp_Minor => "E##m",
            Key.E_Flat_Minor => "Ebm",
            Key.E_Double_Flat_Minor => "Ebbm",

            Key.F_Minor => "Fm",
            Key.F_Sharp_Minor => "F#m",
            Key.F_Double_Sharp_Minor => "F##m",
            Key.F_Flat_Minor => "Fbm",
            Key.F_Double_Flat_Minor => "Fbbm",

            Key.G_Minor => "Gm",
            Key.G_Sharp_Minor => "G#m",
            Key.G_Double_Sharp_Minor => "G##m",
            Key.G_Flat_Minor => "Gbm",
            Key.G_Double_Flat_Minor => "Gbbm",

            Key.A_Minor => "Am",
            Key.A_Sharp_Minor => "A#m",
            Key.A_Double_Sharp_Minor => "A##m",
            Key.A_Flat_Minor => "Abm",
            Key.A_Double_Flat_Minor => "Abb m",

            Key.B_Minor => "Bm",
            Key.B_Sharp_Minor => "B#m",
            Key.B_Double_Sharp_Minor => "B##m",
            Key.B_Flat_Minor => "Bbm",
            Key.B_Double_Flat_Minor => "Bbbm",
            #endregion

            _ => Key.NA.ToString(),

        };
    }



}
