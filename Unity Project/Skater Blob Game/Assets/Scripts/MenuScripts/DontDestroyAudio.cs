using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Dont Destroy Audio Script
 * 
 * Author: Ivan Alberico
 * 
 * This script is used to not destroy the audio objects while going from one scene to the other.
 * 
 */

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
