using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Design Level1 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script represents the core of Level 1. Whenever the Skater Blob collides with the button and
 * puzzle_update() function is called, all the coins appear in the skating park and a countdown is 
 * initialized. A coroutine is started, which counts the amount of time within which you need to finish
 * Level1, and its value is passed through the variable wait_time from ButtonLevel1 class. When the time
 * expires, all the coins disappear again, the counter that counts the number of coins collected is reset
 * to zero, and the button becomes pressable again.
 * 
 */



public class DesignLevel1 : MonoBehaviour
{
    public ButtonLevel1 button1;
    public GameObject countdownObject;
    public GameObject countdownText;
    public CountdownLevel1 countdown;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;

    public GameObject coinScore;

    public GameObject initialDialogue;
    public GameObject timeExpiredDialogue;
    public GameObject finalDialogue;


    public void puzzle_update(ButtonLevel1 curr)
    {
        if (curr == button1)
        {
            // The initial Dialogue box should be displayed only once
            if (button1.initialDialogueNotDisplayed == true)
            {
                initialDialogue.SetActive(true);
                Time.timeScale = 0f;
            }

            button1.initialDialogueNotDisplayed = false;
            button1.resetVariables = false;

            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
            coin7.SetActive(true);
            coin8.SetActive(true);

            coinScore.SetActive(true);

            countdownObject.SetActive(true);
            countdownText.SetActive(true);
            countdown.Start();
            countdown.Update();

            button1.pressable = false;
            button1.puzzleTime_over = false;
            button1.GetComponent<Renderer>().material.mainTexture = button1.Ton;

            StartCoroutine(TimeBeforeDisappearing());
            
        }

    }


    IEnumerator TimeBeforeDisappearing()
    {

        yield return new WaitForSeconds(button1.wait_time);


        if (!button1.puzzle_completed)
        {

            if (button1.timeExpiredDialogueNotDisplayed == true)
            {
                timeExpiredDialogue.SetActive(true);
                Time.timeScale = 0f;
            }

            button1.timeExpiredDialogueNotDisplayed = false;
            button1.resetVariables = true;

            coin1.SetActive(false);
            coin2.SetActive(false);
            coin3.SetActive(false);
            coin4.SetActive(false);
            coin5.SetActive(false);
            coin6.SetActive(false);
            coin7.SetActive(false);
            coin8.SetActive(false);

            coinScore.SetActive(false);

            button1.finalized = 0;
            ScoreTextScript.coinAmount = 0;

            countdown.secondsLeft = button1.wait_time;

            countdownObject.SetActive(false);
            countdownText.SetActive(false);

            button1.pressable = true;
            button1.puzzleTime_over = true;
            button1.GetComponent<Renderer>().material.mainTexture = button1.Toff;
           
        }
        
    }


    // When a Dialogue box is displayed, the game is stopped since the timeScale is set to zero.
    // In order to restore the normal conditions it is needed to press the key A.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1f;
            initialDialogue.SetActive(false);
            timeExpiredDialogue.SetActive(false);
            finalDialogue.SetActive(false);
        }
    }


}
