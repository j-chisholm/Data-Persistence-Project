using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HIGH SCORE!\n" +
            GameManager.Instance.highScoreHolder + ": " + GameManager.Instance.highScore;

        playerNameInput.text = GameManager.Instance.lastKnownPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        //save currentPlayerName
        GameManager.Instance.SaveLastKnownPlayerName(playerNameInput.text.ToString());

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
