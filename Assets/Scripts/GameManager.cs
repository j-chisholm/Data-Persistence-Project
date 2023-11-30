using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string highScoreHolder = "N/A";
    public string lastKnownPlayer = "N/A";
    public int highScore = 0;

    private void Awake()
    {
        //Ensure this game object is a singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreData();
    }

    //Store the currentPlayer's name
    public void SaveLastKnownPlayerName(string _lastKnownPlayer)
    {
        lastKnownPlayer = _lastKnownPlayer;
    }

    //Data class to store player's name and score
    [System.Serializable]
    class Data
    {
        public string highSchoreHolder;
        public string lastKnownPlayer;
        public int playerHighScore;
    }

    //Save data function to save the player's 
    public void SaveHighScoreData(int score)
    {
        Data playerData = new Data();
        if (score > highScore)
        {
            playerData.playerHighScore = score;
            playerData.highSchoreHolder = lastKnownPlayer;
        }
        else
        {
            playerData.playerHighScore = highScore;
            playerData.highSchoreHolder = highScoreHolder;
        }

        playerData.lastKnownPlayer = lastKnownPlayer;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Load the player's saved data
    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data playerData = JsonUtility.FromJson<Data>(json);

            highScoreHolder = playerData.highSchoreHolder;
            lastKnownPlayer = playerData.lastKnownPlayer;
            highScore = playerData.playerHighScore;
        }
    }
}
