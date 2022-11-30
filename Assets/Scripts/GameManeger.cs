using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    public static bool gamePause = false;
    private int goldSphireToAdd;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
               
                ResumeGame();
                print("Game isn't paused!");
            }
            else
            {
                PauseGame();
                print("Game is paused!");
            }

        }
    }
    public void GameOver()
    {
      
        Time.timeScale = 0f;
        gameOverPanel.gameObject.SetActive(true);
        
    }

     public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is over");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
       

    }
}
