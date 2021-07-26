using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour
{

    public int coinsToWin;

    public AudioClip sound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        AudioSource.PlayClipAtPoint(sound, transform.position);
        if (other.CompareTag("Player") && other.transform.parent.gameObject.GetComponent<CoinCounter>().coinCount > coinsToWin)
        {
            other.gameObject.GetComponent<PlayerMove>().isMoving = false;
            other.gameObject.transform.parent.gameObject.GetComponent<Move>().isMoving = false;
            FindObjectOfType<Timer>().Complete();
            Debug.Log("Timer Complete");
            FindObjectOfType<GameManager>().WinGame();

        }
        else if (other.CompareTag("Player") && other.transform.parent.gameObject.GetComponent<CoinCounter>().coinCount <= coinsToWin)
        {
            other.gameObject.GetComponent<PlayerMove>().isMoving = false;
            other.gameObject.transform.parent.gameObject.GetComponent<Move>().isMoving = false;
            FindObjectOfType<GameManager>().NoCoins();
            Debug.Log("Lose Game");
            FindObjectOfType<Timer>().Complete();

        }
        else
        {
            Debug.Log("WTF");
        }
    }
}