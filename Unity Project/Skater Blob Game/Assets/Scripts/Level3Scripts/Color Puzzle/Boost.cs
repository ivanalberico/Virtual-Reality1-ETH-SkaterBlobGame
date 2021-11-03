using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{   

    //Collision handler for the speed boost button, which starts the color matching puzzle (activating the boost is handled in the puzzle controller)

    public bool pressable;
    public bool finalized;
    public ColorPuzzlecont cont;

    private void OnTriggerEnter(Collider other) {

        if(this.pressable && !this.finalized){
            cont.startpuzzle();         
            
        }
    }
}
