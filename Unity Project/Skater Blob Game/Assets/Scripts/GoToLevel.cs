using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * 
 * Author: Ivan Alberico
 * 
 * This script handles the loading of the different levels.
 * 
 */


public class GoToLevel : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level1")
        {
            SceneManager.LoadScene("Level 1");
        }

        if (collision.gameObject.tag == "Level2")
        {
            SceneManager.LoadScene("Level 2");
        }

        if (collision.gameObject.tag == "Level3")
        {
            SceneManager.LoadScene("Level 3");
        }
    }



}
