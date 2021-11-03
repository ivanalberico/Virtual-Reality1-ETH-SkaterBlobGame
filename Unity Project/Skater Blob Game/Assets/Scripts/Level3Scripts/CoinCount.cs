using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCount : MonoBehaviour
{   

    // HUD script to display collected amount of coins
    
    Text text;
    public LevelCont cont;
     void Start()
    {
        text = GetComponent<Text>();
    }

    
    void Update()
    {
        text.text = cont.collectedCoins.ToString();
    }
}
