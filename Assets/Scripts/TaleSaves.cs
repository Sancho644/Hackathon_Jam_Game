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
    Tale2 = 0,
    Tale3 = 0,
    Tale4 = 0,
    Tale5 = 0,
}