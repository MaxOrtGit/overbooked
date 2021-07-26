using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howtoplayUI;
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

        public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    { 
        SceneManager.LoadScene("Main Menu");
    }
    public void HowToPlay()
    {
        howtoplayUI.SetActive(true);

    }
}