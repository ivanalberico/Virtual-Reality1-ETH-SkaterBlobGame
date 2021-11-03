using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarButton : MonoBehaviour
{
    
    public bool pressed;
    public bool finalized;
    bool pressable;
    public StarPuzzleCon cont;

    public Texture Toff;
    public Texture Ton;
    public Texture Tfinal;

    void Start()
    {
        this.pressed = false;
        this.pressable = true;
        this.finalized = false;
        this.GetComponent<Renderer>().material.mainTexture = Toff;

    }

    //handles button press, only allowed buttons that are "off" to be pressed  

    private void OnTriggerEnter(Collider other) {

        if(!this.finalized && this.pressable){
            button_press();          
            this.cont.puzzle_update(this);
            
        }
    }
    public void button_press(){
        if(this.pressed){
                this.GetComponent<Renderer>().material.mainTexture = Toff;
            } else{
                this.GetComponent<Renderer>().material.mainTexture = Ton;
            }
        this.pressed = !this.pressed;
        if(this.pressed == false){
            this.pressable = true;
        }else{
            this.pressable = false;
        }

    }

    public void finalize(){
        this.finalized = true;
        this.GetComponent<Renderer>().material.mainTexture = Tfinal;
    }
}
