using System.IO;
using UnityEngine;

public static class SaveLoadManager
{
    private static string path => Path.Combine(Application.persistentDataPath, "savegame.json");

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log($"Data saved to: {path}");
    }

    public static GameData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("Save file not found, creating new one.");
            return new GameData();
        }
    }
}
