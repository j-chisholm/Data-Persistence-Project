using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] InputField playerNameInput;

    private void Awake()
    {

        //highScoreText.text = "HIGH SCORE!\n" +
          //  MainManager.Instance.playerName + ": " + MainManager.Instance.highScore;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
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
