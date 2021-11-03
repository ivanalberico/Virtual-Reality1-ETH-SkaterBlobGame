using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/**
 * Countdown Level1 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script describes the design of the countdown mechanism in Level1.
 * 
 */


public class CountdownLevel1 : MonoBehaviour
{
    public GameObject textDisplay;
    public ButtonLevel1 button;

    public int secondsLeft;
    public bool takingAway = false;


    public void Start()
    {
        takingAway = false;
        secondsLeft = button.wait_time;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<TMP_Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<TMP_Text>().text = "00:" + secondsLeft;
        }
    }


    public void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        if (button.puzzleTime_over)
        {
            secondsLeft = button.wait_time;
        }

    }

    /** Thanks to the TimerTake() coroutine, at each second the countdown is reduced by one.
     *  When the number of seconds left is less than 10, an additional 0 should be displayed.
     */

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<TMP_Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<TMP_Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;

    }
}
