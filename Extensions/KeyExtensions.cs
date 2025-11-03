namespace SongManager.Desktop.Extensions;

public static class KeyExtensions
{
    public static List<KeyDto> ToKeyList(this string keyField)
    {
        if (string.IsNullOrWhiteSpace(keyField))
            return new List<KeyDto>();

        var keyFieldToList = keyField.Split('/', StringSplitOptions.RemoveEmptyEntries | 
                                                 StringSplitOptions.TrimEntries)
                                     .Select(k => k.ToUpperInvariant())
                                     .ToList();


        var keys = keyFieldToList;
        if (keys.Count == 0) return new List<KeyDto>();

        var allKeyDtos = GlobalVariables.Keys;
        return allKeyDtos
            .Where(k => keys.Contains(k.Name.ToUpperInvariant()))
            .ToList();
    }
}
