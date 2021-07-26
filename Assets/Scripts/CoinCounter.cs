using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;

    public Text coinText;
    public Text highscoreText;

    void CoinDisplay()
    {

        coinText.text = string.Format(coinCount + " Coins");
    }
    private void Update()
    {
        CoinDisplay();
    }
}
