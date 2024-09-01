using Agava.YandexGames;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class SaveLoader
{
    private Dictionary<string, int> _keyValuePairs = new Dictionary<string, int>();

    public bool IsInitialized { get; private set; }

    public void Initialize()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.GetCloudSaveData(result =>
        {
            if (string.IsNullOrEmpty(result) == false)
                _keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);

            IsInitialized = true;
        });
#endif
    }

    public void Save(string key, int value)
    {
        if (_keyValuePairs.ContainsKey(key))
            _keyValuePairs[key] = value;
        else
            _keyValuePairs.Add(key, value);
        
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.SetCloudSaveData(JsonConvert.SerializeObject(_keyValuePairs, Formatting.Indented));
#endif
    }

    public int LoadOrDefault(string key)
    {
        return _keyValuePairs.ContainsKey(key) ? _keyValuePairs[key] : 0;
    }
}
