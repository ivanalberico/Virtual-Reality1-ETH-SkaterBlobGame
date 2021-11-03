using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LowerRingPuzzleCont : MonoBehaviour
{
   

    public LowerRingButton starter;
    public GameObject bridge;
    public CoinL3 coin;
    public bool finished;
    public int timer;
    public LowerRingTimer display;
    public TimerExtra extra;

    void Start()
    {
        bridge.gameObject.SetActive(false);
        finished = false;
        display.gameObject.SetActive(false);
        extra.gameObject.SetActive(false);
    }


    // starts timer and spawns bridge block
    public void puzzle_update(LowerRingButton curr){
       if(!this.finished){
            bridge.gameObject.SetActive(true);
            StartCoroutine(startTimer());
        }
    }

    // spawns bridge block indefinitely after puzzle is cleared
    public void collected(){
        starter.finalize();
        bridge.gameObject.SetActive(true);
        finished = true;
    }

    // Coroutine for handling the timer and handles despawn of the bridge block after timer expires
   IEnumerator startTimer(){
        display.gameObject.SetActive(true);
        extra.gameObject.SetActive(true);
        timer = 40;
        while(timer > 0){
        yield return new WaitForSeconds(1);
            timer--;
            if(finished) break;
        }
        if(!finished){
            bridge.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            display.gameObject.SetActive(false);
            extra.gameObject.SetActive(false);
            starter.button_switch_off();
        } else{
            yield return new WaitForSeconds(3);
            display.gameObject.SetActive(false);
            extra.gameObject.SetActive(false);
        }
    }
}
