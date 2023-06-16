using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGameStarted;
    public int score;

    private GameObject gameOverScreen;
    private GameObject startScreen;
    private GameObject inGameStat;
    private GameObject lifeBar;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGameStarted = false;
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(false);
        startScreen = GameObject.Find("StartScreen");
        startScreen.SetActive(true);
        inGameStat = GameObject.Find("InGameStat");
        inGameStat.SetActive(false);
        lifeBar = GameObject.Find("Lifebar");
        lifeBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            inGameStat.SetActive(false);
            lifeBar.SetActive(false);
        }
    }
    public void SetGameOver()
    {
        isGameOver = true;
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void StartGame()
    {
        isGameOver = false;
        isGameStarted = true;
        startScreen.SetActive(false);
        inGameStat.SetActive(true);
        lifeBar.SetActive(true);
    }
}
