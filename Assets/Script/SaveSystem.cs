using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveSystem
{
    private static string SavePath => Application.persistentDataPath + "/save/";

    public static void Save(GameData gameData, string saveFileName)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        string saveJson = JsonUtility.ToJson(gameData);

        string saveFilePath = SavePath + saveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        
    }

    public static GameData Load(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";
        if (!File.Exists(saveFilePath))
        {
            return null;
        }
        string saveFile = File.ReadAllText(saveFilePath);
        GameData gameData = JsonUtility.FromJson<GameData>(saveFile);
        return gameData;
    }
}
//https://lefthanddeveloper.tistory.com/15