using Agava.YandexGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class SaveLoader
{
    private List<SaveData> _keyValuePairs = new List<SaveData>();

    private string _json;

    public void Initialize()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.GetCloudSaveData(result => _json = result);

        if (string.IsNullOrEmpty(_json) == false)
        {
            string[] pairs = _json.Split('@');
            _keyValuePairs.Clear();
            
            foreach (var pair in pairs)
                _keyValuePairs.Add(JsonUtility.FromJson<SaveData>(pair));
        }
#endif
    }

    public void Save(string key, int value)
    {
        SaveData data = _keyValuePairs.Find(element => element.Key == key);

        if (data != null)
            data.Value = value;
        else
            _keyValuePairs.Add(new SaveData(key, value));

        _json = string.Empty;

        foreach (var pair in _keyValuePairs)
        {
            if (_json == null)
                _json = JsonUtility.ToJson(pair) + "@";
            else
                _json += JsonUtility.ToJson(pair) + "@";
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.SetCloudSaveData(_json);
#endif
    }

    public int LoadOrDefault(string key)
    {
        SaveData data = _keyValuePairs.Find(element => element.Key == key);

        if (data == null)
            data = new SaveData(key, 0);

        _keyValuePairs.Add(data);

        return data.Value;
    }

    [Serializable]
    private class SaveData
    {
        public SaveData(string key, int value)
        {
            Key = key;
            Value = value;
        }

        public string Key;
        public int Value;
    }
}
