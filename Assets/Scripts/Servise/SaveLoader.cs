using UnityEngine;

public class SaveLoader
{
    public void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public int LoadOrDefault(string key)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetInt(key);

        return 0;
    }
}
