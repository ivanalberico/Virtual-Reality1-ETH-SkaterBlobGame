using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Pause Menu Script
 * 
 * Author: Ivan Alberico
 * 
 * This script manages the Pause menu while playing the different levels. Whenever the 'Esc' key is pressed,
 * the game is either paused if it was not, or viceversa. When the Pause Menu is called, the game should stop,
 * in fact the Pause() function is called, where the timeScale is set to 0. When we want to resume the game, 
 * the Resume() function is called, which sets the pauseMenuUI canvas to false, and restores the normal timeScale.
 * Inside the Pause Menu you have the options to also go back to the Main menu (thanks to the LoadMenu() function)
 * or to directly quit the game (thanks to the QuitGame() function).
 * 
 */

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
        GameIsPaused = false;
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
