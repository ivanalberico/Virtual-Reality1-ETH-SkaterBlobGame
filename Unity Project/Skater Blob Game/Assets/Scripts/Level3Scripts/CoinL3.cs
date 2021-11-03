using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinL3 : MonoBehaviour
{   

    //Script that handles rotating animation for coins and the collection of the coin on collision with it
    

    public GameObject player;
    public LevelCont levelcont;
    
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 100*Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other) {
            levelcont.Collect(this.gameObject);
    }

}
