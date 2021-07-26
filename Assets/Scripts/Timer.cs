using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    public PlayerMove toStop;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main Menu");
            SceneManager.LoadScene("Main Scene");
        }


        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                Debug.Log("The Train Filled Up!");
                timeRemaining = 0f;
                timerIsRunning = false;
                toStop.isMoving = false;
                toStop.gameObject.transform.parent.gameObject.GetComponent<Move>().isMoving = false;
                FindObjectOfType<GameManager>().LoseGame();
            }
        }
    }
    public void Complete()
    {
        timerIsRunning = false;
    }
    void DisplayTime(float timeToDisplay)
    {


        timeText.text = "Train Is " + string.Format("{0:F0}", (100 - timeToDisplay)) + "% Full";
    }
}