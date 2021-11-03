using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Button Level1 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script defines all the methods and attributes that are triggered when the Skater Blob
 * collides with the button to start Level 1.
 * 
 */


public class ButtonLevel1 : MonoBehaviour
{
    public DesignLevel1 cont;
    public int finalized;
    public bool pressable;
    public bool puzzleTime_over;
    public bool puzzle_completed = false;

    public Texture Toff;
    public Texture Ton;
    public Texture Tfinal;

    public int wait_time;

    public bool initialDialogueNotDisplayed;
    public bool timeExpiredDialogueNotDisplayed;

    public bool resetVariables;


    // When the Start method is called, all the variables are initialized
    void Start()
    {
        this.pressable = true;
        this.finalized = 0;
        this.puzzleTime_over = false;

        this.wait_time = 59;

        this.initialDialogueNotDisplayed = true;
        this.timeExpiredDialogueNotDisplayed = true;

        this.GetComponent<Renderer>().material.mainTexture = Toff;

        this.resetVariables = false;

    }


    /** When the Skater Blob collides with the button, the function puzzle_update of the class DesignLevel1
     *  is called, which handles the whole mechanism of Level1. Moreover, the button cannot be pressed while
     *  completing Level1.
    */

    private void OnTriggerEnter(Collider other)
    {

        if ((this.finalized != 8) && this.pressable)
        {
            this.cont.puzzle_update(this);
            this.pressable = false;
        }
    }


    // The button becomes pressable again when the time needed to solve Level1 is expired.

    private void OnTriggerExit(Collider other)
    {
        if (this.puzzleTime_over) {
            this.pressable = true;
        }
    }

}
