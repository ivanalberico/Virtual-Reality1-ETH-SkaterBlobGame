using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Completion Level1 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script describes the winning condition for Level1. Whenever the Skater Blob collides with a coin,
 * the counter is incremented and the corresponding coin becomes not active anymore. When all the coins are collected
 * within the specified amount of time, a Dialogue box appears, the button changes color (it cannot be pressed
 * anymore) and a box collider named goToNextLevel is set to active.
 * 
 */


public class Level1Completion : MonoBehaviour
{
    public ButtonLevel1 button;
    public GameObject countdownObject;
    public GameObject countdownText;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;

    public GameObject finalDialogue;
    public GameObject goToNextLevel;

    public bool coin1taken;
    public bool coin2taken;
    public bool coin3taken;
    public bool coin4taken;
    public bool coin5taken;
    public bool coin6taken;
    public bool coin7taken;
    public bool coin8taken;


    private void Update()
    {
        if (button.resetVariables)
        {
            coin1taken = false;
            coin2taken = false;
            coin3taken = false;
            coin4taken = false;
            coin5taken = false;
            coin6taken = false;
            coin7taken = false;
            coin8taken = false;
        }

    }


    private void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.CompareTag("Coin(4)(1)"))
        {
            if (!coin1taken) {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin1.SetActive(false);

                coin1taken = true;
            }


            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }
            
        }


        if (thing.gameObject.CompareTag("Coin(4)(2)"))
        {
            if (!coin2taken) {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin2.SetActive(false);

                coin2taken = true;
            }


            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }

        }



        if (thing.gameObject.CompareTag("Coin(4)(3)"))
        {
            if (!coin3taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin3.SetActive(false);

                coin3taken = true;
            }

            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;

            }

        }


        if (thing.gameObject.CompareTag("Coin(4)(4)"))
        {
            if (!coin4taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin4.SetActive(false);

                coin4taken = true;
            }

            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;

            }

        }



        if (thing.gameObject.CompareTag("Coin(4)(5)"))
        {
            if (!coin5taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin5.SetActive(false);

                coin5taken = true;
            }

            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }

        }


        if (thing.gameObject.CompareTag("Coin(4)(6)"))
        {
            if (!coin6taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin6.SetActive(false);

                coin6taken = true;
            }


            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }

        }



        if (thing.gameObject.CompareTag("Coin(4)(7)"))
        {
            if (!coin7taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin7.SetActive(false);

                coin7taken = true;
            }

            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }

        }



        if (thing.gameObject.CompareTag("Coin(4)(8)"))
        {
            if (!coin8taken)
            {
                button.finalized += 1;
                ScoreTextScript.coinAmount += 1;
                coin8.SetActive(false);

                coin8taken = true;
            }

            if (button.finalized == 8 && ((coin1.active == false) && (coin2.active == false) && (coin3.active == false) && (coin4.active == false) && (coin5.active == false) && (coin6.active == false) && (coin7.active == false) && (coin8.active == false)))
            {
                countdownObject.SetActive(false);
                countdownText.SetActive(false);

                button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                button.puzzle_completed = true;

                finalDialogue.SetActive(true);
                goToNextLevel.SetActive(true);
                Time.timeScale = 0f;
            }

        }





    }



}
