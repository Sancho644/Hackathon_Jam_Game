using System.Collections.Generic;

public static class TaleSaves
{
    private static Dictionary<TalesNames, TaleProperties> _taleSaves;

    private static Dictionary<TalesNames, TaleProperties> Saves => _taleSaves ??= new Dictionary<TalesNames, TaleProperties>();

    public static TaleProperties GetSave(TalesNames key)
    {
        if (Saves.TryGetValue(key, out var save))
        {
            return save;
        }

        Saves.Add(key, new TaleProperties());

        return Saves[key];
    }
}

public enum TalesNames
{
    TaleScene = 0,
    TaleScene2 = 1,
    TaleScene3 = 2,
    TaleScene4 = 3,
    TaleScene5 = 4,
}