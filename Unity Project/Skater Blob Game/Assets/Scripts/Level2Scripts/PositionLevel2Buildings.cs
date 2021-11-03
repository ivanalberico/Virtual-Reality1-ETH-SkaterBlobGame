using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Position Level2 Buildings Script
 * 
 * Author: Ivan Alberico
 * 
 * This script allows you to instantaeously restart from the first building whenever you fall
 * down from any building in the second part of the level.
 * 
 */


public class PositionLevel2Buildings : MonoBehaviour
{
    public GameObject SkaterBlob;
    //public PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        SkaterBlob.transform.position = new Vector3(46.76f, 21.05f, 38.28f);
        SkaterBlob.transform.eulerAngles = new Vector3(0.051f, -90.002f, 0f);
        //controller.vel = new Vector3(0f, 0f, 0f);
        SkaterBlob.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
