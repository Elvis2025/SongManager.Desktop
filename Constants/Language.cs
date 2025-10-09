using SongManager.Desktop.Resx;

namespace SongManager.Desktop.Constants;

public sealed class Language
{
    public static Language Spanish => new(SongManagerResources.Spanish, "es-ES");
    public static Language English => new(SongManagerResources.English, "en-US");
    public static Language French => new(SongManagerResources.French, "fr-FR");
    public static Language Portuguese => new(SongManagerResources.Portuguese, "pt-PT");
    public static Language Italian => new(SongManagerResources.Italian, "it-IT");
    public static Language German => new(SongManagerResources.German, "de-DE");

    public string Name { get; }
    public string Code { get; }

    private Language(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public override string ToString() => Code;

    public static IEnumerable<Language> List() => new[] { English, Spanish, French, Portuguese, Italian, German };
    public static Language FindLanguage(string code) => List().FirstOrDefault(x => x.Code == code) ?? Spanish;

    public static Language FromCode(string code) =>
        List().FirstOrDefault(x => x.Code == code) ?? English;

    public static Language FromName(string name) =>
        List().FirstOrDefault(x => x.Name == name) ?? English;
}
