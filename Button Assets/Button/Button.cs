using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public bool pressed;
    public Puzzle_control cont;
    public bool finalized;
    bool pressable;
   	
   	public Texture Toff;
   	public Texture Ton;
   	public Texture Tfinal;
	
    // Start is called before the first frame update
    void Start()
    {
        this.pressed = false;
        this.pressable = true;
        this.finalized = false;
        this.GetComponent<Renderer>().material.mainTexture = Toff;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        if(!this.finalized && this.pressable){
            button_press();          
            this.cont.puzzle_update(this);
            this.pressable = false;
        }
    }

    public void button_press(){
        if(this.pressed){
                   this.GetComponent<Renderer>().material.mainTexture = Toff;
            } else{
                    this.GetComponent<Renderer>().material.mainTexture = Ton;
            }
        this.pressed = !this.pressed;
    }
    
    private void OnTriggerExit(Collider other){
        this.pressable = true;
    }

}
