using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string currentPlayer;
    public string player;
    public int highscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        Load();
    }

    [System.Serializable]
    private class SaveData
    {
        public string Player;
        public int Highscore;
    }

    public void Save()
    {
        SaveData data = new SaveData();

        data.Player = player;
        data.Highscore = highscore;

        // Serialize data to json
        string json = JsonUtility.ToJson(data);

        Debug.Log("SAVE: " + json);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            Debug.Log("LOAD: " + json);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            player = data.Player;
            highscore = data.Highscore;
        }

    }
}
