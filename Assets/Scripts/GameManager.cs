using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject loseUI;
    public GameObject WinUI;
    public GameObject NoCoinsUI;

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Invoke("Restart", restartDelay);

        }
    }

    public void LoseGame()
    {
        loseUI.SetActive(true);
        EndGame();
    }
    public void WinGame()
    {
        WinUI.SetActive(true);
        EndGame();
    }
    public void NoCoins()
    {
        NoCoinsUI.SetActive(true);
    }
}
