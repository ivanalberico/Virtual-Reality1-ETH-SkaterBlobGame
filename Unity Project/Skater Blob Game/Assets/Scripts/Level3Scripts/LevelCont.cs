using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCont : MonoBehaviour
{   

    //Counts amount of collected coins every time a new one is collected and enables the exit as soon as all are collected

    public CoinL3 cLowerRing;
    public CoinL3 cMiddle_Platform;
    public CoinL3 cRail;
    public CoinL3 cStar;
    public CoinL3 cColor;
    public int collectedCoins;
    public LowerRingPuzzleCont lrpcont;
    public ColorPuzzlecont cpcont;
    public Exit exit;
    void Start()
    {
       collectedCoins = 0;
       exit.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void Collect(GameObject c){
        if(c == cLowerRing.gameObject || c == cMiddle_Platform.gameObject || c == cRail.gameObject || c == cStar.gameObject || c == cColor.gameObject ){
            collectedCoins += 1;
            Wincondition();
            if(c == cLowerRing.gameObject){
            lrpcont.collected();
            }
            if(c == cColor.gameObject){
            cpcont.collected();
            }
            c.SetActive(false);
            
        }


    }

    private void Wincondition(){
        if(collectedCoins >= 5){
            exit.gameObject.SetActive(true);
        }
    }
}
