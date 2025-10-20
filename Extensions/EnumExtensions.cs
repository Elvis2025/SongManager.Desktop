namespace SongManager.Desktop.Extensions;

public static class EnumExtensions
{
    public static string GetKeyName(this Key keyString)
    {
        return keyString switch
        {
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
            Key.NA => "N/A",
            _ => "Unknown"

        };
    }



}
