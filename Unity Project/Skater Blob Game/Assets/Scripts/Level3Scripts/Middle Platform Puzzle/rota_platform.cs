using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota_platform : MonoBehaviour
{
    
    // Constantly rotates a platform

    public GameObject player;
    public int x = 5;

    void Start()
    {
        
    }

    
    void Update ()
    {   
        transform.Rotate(0,25*Time.deltaTime,0); //rotates 50 degrees per second around z axis

    }
    public void OnTriggerEnter(Collider other) {
        player.transform.parent = transform;

    }
    public void OnTriggerExit(Collider other) {
        player.transform.parent = null;

    }

}
