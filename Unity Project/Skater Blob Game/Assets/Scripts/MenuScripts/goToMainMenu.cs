using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Load Main Menu Script
 * 
 * Author: Ivan Alberico
 * 
 * This script automatically loads the Main Menu right after the Intro has been displayed (the Intro lasts around 9 seconds)
 * 
 */


public class goToMainMenu : MonoBehaviour
{
    public float wait_time = 9f;

    void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(1);

    }
}
