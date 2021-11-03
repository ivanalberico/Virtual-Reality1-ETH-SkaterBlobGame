using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Handles the level exit Collision box to return back to the lobby
  
    private void OnTriggerEnter(Collider collision)
    {
        
            SceneManager.LoadScene("Lobby");
    }   
}
