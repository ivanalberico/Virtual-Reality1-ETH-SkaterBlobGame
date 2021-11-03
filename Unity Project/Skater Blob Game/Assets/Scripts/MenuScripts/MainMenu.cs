using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Main Menu Script
 * 
 * Author: Ivan Alberico
 * 
 * This script sets the action for the Play and Quit buttons inside the Main Menu.
 * When the 'Play' button is pressed, the next scene is loaded thanks to the 
 * SceneManager. When the 'Quit' button is pressed, the game is shot down.
 * 
 */


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("The game has ended!");
        Application.Quit();
    }
}
