using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Initial Position Level2 Script
 * 
 * Author: Ivan Alberico
 * 
 * This script allows you to instantaeously restart from the initial position whenever you fall inside
 * the skating park or you collide with a white box (teleport) which is located on the street.
 * 
 */


public class InitialPositionLevel2 : MonoBehaviour
{
    public GameObject SkaterBlob;

    private void OnTriggerEnter(Collider other)
    {
        SkaterBlob.transform.position = new Vector3(-0.824727f, 0.2256285f, 30.04486f);
        SkaterBlob.transform.eulerAngles = new Vector3(0.051f, -90.002f, 0f);
        SkaterBlob.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
