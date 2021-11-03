using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    
    //Constantly moves a platform back and forth

    public GameObject player;
    bool dir = false;
    double dist = 0;

    void Start()
    {
        
    }

    
    void Update(){   
        if(dir){
            transform.Translate(1*Time.deltaTime,0,0); 
            dist += 1*Time.deltaTime;
            if(dist >= 6.0){
                dist = 0.0;
                dir =  !dir;
            }

        } else {
            transform.Translate(-(1*Time.deltaTime),0,0); 
            dist += 1*Time.deltaTime;
            if(dist >= 6.0){
                dist = 0.0;
                dir = !dir;
            }
        }

    }


   

}
