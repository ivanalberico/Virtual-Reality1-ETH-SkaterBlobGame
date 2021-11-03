using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Button Level2 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script defines all the methods and attributes that are triggered when the Skater Blob
 * collides with the button to start Level 2.
 * 
 */


public class ButtonLevel2 : MonoBehaviour
{
    public bool finalized;
    public bool pressable;
    public GameObject platform1;
    public GameObject platform7;
    public GameObject platform8;
    public GameObject platform9;
    public GameObject platform10;
    public GameObject platform11;
    public GameObject platform12;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;


    public Texture Toff;
    public Texture Ton;
    public Texture Tfinal;

    public int wait_time;


    void Start()
    {
        this.pressable = true;
        this.finalized = false;

        this.GetComponent<Renderer>().material.mainTexture = Toff;

    }


    // When the button is pressed, some of the game objects in Level 2 become active (not all of them)

    private void OnTriggerEnter(Collider other)
    {

        if (!this.finalized && this.pressable)
        {
            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(true);

            platform1.SetActive(true);
            platform7.SetActive(true);
            platform8.SetActive(true);
            platform9.SetActive(true);
            platform10.SetActive(true);
            platform11.SetActive(true);
            platform12.SetActive(true);

            this.pressable = false;

            this.GetComponent<Renderer>().material.mainTexture = Ton;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        this.pressable = true;
    }

}