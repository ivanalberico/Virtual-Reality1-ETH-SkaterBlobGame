using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Design Level2 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script represents the core of Level 2. To complete the level, it is necessary to collect
 * 3 coins that are distributed in the scene. You need to follow a predefined path to encounter 
 * all the 3 coins.
 * 
 */


public class DesignLevel2 : MonoBehaviour
{
    public ButtonLevel2 button;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform5;
    public GameObject platform6;
    public GameObject platform7;
    public GameObject platform7_8;
    public GameObject platform8;
    public GameObject platform9;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;

    public bool activate_sequence;
    public int sequence_count = 0;
    public int switching_frequency = 160;

    public int totalCoins;

    public GameObject finalDialogue;
    public GameObject goNextLevel;

    public bool displayed;



    // At the beginning, the counter is initialized to zero
    private void Start()
    {
        totalCoins = 0;
        displayed = false;         // the winning condition is achieved only once, as long as 'displayed' is equal to false 
        activate_sequence = true;
        ScoreTextScript.coinAmount = 0;
    }



    // At each step we check if the winning conditions are met. If so, the button changes color and it cannot be pressed anymore,
    // the object goNextLevel becomes active and the final dialogue box is displayed. To make the dialogue box disappear and to
    // restore the normal timeScale, it is enough to press the key 'A' (this is checked at each step)
    private void Update()
    {
        if ((totalCoins == 3) && !displayed)
        {
            button.finalized = true;
            button.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);

            goNextLevel.SetActive(true);

            finalDialogue.SetActive(true);
            displayed = true;
            Time.timeScale = 0f;

        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1f;
            finalDialogue.SetActive(false);
        }
    }



    // The first 3 platforms appear only once you enter in a collision with the previous one
    // As soons as you jump on the third platform, the ActivateSequence() method is called, which
    // manages the switching sequence of the following 3 platforms (4, 5 and 6)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform1")
        {
            platform2.SetActive(true);
        }


        if (collision.gameObject.tag == "Platform2")
        {
            platform3.SetActive(true);
        }


        if (collision.gameObject.tag == "Platform3")
        {

            platform7_8.SetActive(true);                     // this is the platform right after the sequence of the 3 alternating platform


            if (activate_sequence == true)
            {
                ActivateSequence();
            }

            

        }

    }



    // When the Skater Blob collides with a coin, the totalCoins variable gets updated and the corresponding coin is set to inactive.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin(1)"))
        {
            totalCoins += 1;
            ScoreTextScript.coinAmount += 1;
            coin1.SetActive(false);
        }


        if (other.gameObject.CompareTag("Coin(2)"))
        {
            totalCoins += 1;
            ScoreTextScript.coinAmount += 1;
            coin2.SetActive(false);
        }


        if (other.gameObject.CompareTag("Coin(3)"))
        {
            totalCoins += 1;
            ScoreTextScript.coinAmount += 1;
            coin3.SetActive(false);

        }
    }



    // Once the ActivateSequence() method is called, at each second, there is one platform which is active, while
    // the other two are inactive, following a sequential order. After the last platform of the sequence, the
    // ActivateSequence() method is called again, so that the sequence is repeated infinitely often until the level is finished.

    private void ActivateSequence()
    {
        activate_sequence = false;
        StartCoroutine(PlatformSequence());
    }



    IEnumerator PlatformSequence()
    {
        yield return new WaitForSeconds(1);
        sequence_count += 1;

        StartCoroutine(Platform1());

    }



    IEnumerator Platform1()
    {

        yield return new WaitForSeconds(1);

        platform4.SetActive(true);
        platform5.SetActive(false);
        platform6.SetActive(false);

        StartCoroutine(Platform2());

    }

    IEnumerator Platform2()
    {

        yield return new WaitForSeconds(1);

        platform4.SetActive(false);
        platform5.SetActive(true);
        platform6.SetActive(false);

        StartCoroutine(Platform3());

    }

    IEnumerator Platform3()
    {

        yield return new WaitForSeconds(1);

        platform4.SetActive(false);
        platform5.SetActive(false);
        platform6.SetActive(true);

        ActivateSequence();
    }


}