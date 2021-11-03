using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerRingButton : MonoBehaviour
{  
    public bool finalized;
    bool pressable;
    public LowerRingPuzzleCont cont;

    public Texture Toff;
    public Texture Ton;
    public Texture Tfinal;
   
    void Start()
    {
    
        this.pressable = true;
        this.finalized = false;
        this.GetComponent<Renderer>().material.mainTexture = Toff;
    }

   
    void Update()
    {
        
    }
    //starts puzzle (timer) on press
    private void OnTriggerEnter(Collider other) {

        if(!this.finalized && this.pressable){
            this.pressable = false;
            this.GetComponent<Renderer>().material.mainTexture = Ton;        
            this.cont.puzzle_update(this);
            
        }
    }
    //resets the button after time expires if coin is not collected
    public void button_switch_off(){
            if(!finalized){
                this.GetComponent<Renderer>().material.mainTexture = Toff;
                this.pressable = true;
            }

    }
    //completely deactivates button after puzzle is cleared
    public void finalize(){
        this.finalized = true;
        this.GetComponent<Renderer>().material.mainTexture = Tfinal;
    }
}
