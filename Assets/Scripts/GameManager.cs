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
    public int highScore = 0;
    public string currentPlayer = "N/A";

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Store the currentPlayer's name
    public void SaveCurrentPlayerName(string _currentPlayer)
    {
        currentPlayer = _currentPlayer;
    }

    //Data class to store player's name and score
    [System.Serializable]
    class Data
    {
        public string playerName;
        public int playerHighScore;
    }

    //Save data function to save the player's 
    public void SaveHighScoreData()
    {
        Data playerData = new Data();
        playerData.playerName = currentPlayer;
        playerData.playerHighScore = highScore;

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

            highScoreHolder = playerData.playerName;
            highScore = playerData.playerHighScore;
        }
    }
}
