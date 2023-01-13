using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager
{
    private SerializedData serializedData;
    
    
    public void Save()
    {
        var player = GameObject.Find("Player").transform.position;
        serializedData = new SerializedData
        {
            serHealth = GameData.PlayerHealth,
            serScore = GameData.PlayerScore,
            serAmmo = GameData.BulletAmmo,
            position =
            {
                [0] = player.x,
                [1] = player.y,
                [2] = player.z
            },
            currentScene = GameData.CurrentScene
        };

        var jsonSave = JsonUtility.ToJson(serializedData);
        File.WriteAllText(Application.persistentDataPath + "/StickmanData.json", jsonSave);
        
        Debug.Log("Saved data!");
    }

    public void Load()
    {
        serializedData = new SerializedData();

        if (File.Exists(Application.persistentDataPath + "/StickmanData.json"))
        {
            GameData.PlayerPosition = new float[3];
            var jsonLoad = File.ReadAllText(Application.persistentDataPath + "/StickmanData.json");
            serializedData = JsonUtility.FromJson<SerializedData>(jsonLoad);

            GameData.PlayerHealth = serializedData.serHealth;
            GameData.PlayerScore = serializedData.serScore;
            GameData.BulletAmmo = serializedData.serAmmo;
            GameData.CurrentScene = serializedData.currentScene;

            GameData.PlayerPosition[0] = serializedData.position[0];
            GameData.PlayerPosition[1] = serializedData.position[1];
            GameData.PlayerPosition[2] = serializedData.position[2];

            Debug.Log("Loaded data!");
        }
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/StickmanData.json"))
        {
            File.Delete(Application.persistentDataPath + "/StickmanData.json");
            Debug.Log("Data deleted!");
        }
    }
}
