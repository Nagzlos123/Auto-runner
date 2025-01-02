using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManeger : MonoBehaviour
{

    public void StarGame()
    {
        SceneManager.LoadScene("Game");
    }
  public void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
}
