using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{   
    
    

    public Texture original;
    public Texture activated;
    public Texture deactivated;
    public bool used;
    public bool finalized;
    public bool pressed;
    public ColorSection section;
    
    
    void Start(){
        this.used = false;
        this.finalized = false;
        this.pressed = false;
        this.GetComponent<Renderer>().material.mainTexture = original;
    }
    void Update(){
        
    }
    //reset the button texture and makes it pressable again after puzzle is failed
    public void reset(){
        if(!finalized){
            this.GetComponent<Renderer>().material.mainTexture = original;
            this.used = false;
            this.pressed = false;
        }
    }


    //triggers a button press to the colorsection script and changes color to white
    private void OnTriggerEnter(Collider other) {

        if(!this.finalized && !this.used){
            this.used = true;
            this.pressed = true;
            section.puzzle_update(this.gameObject);
            this.GetComponent<Renderer>().material.mainTexture = activated;          
            
        }
    }
    //for deactivating a whole 3-set of buttons after one of them is pressed, and changes color to black
    public void deactivate(){
        if(!this.finalized && !this.used){
            this.used = true;
            this.GetComponent<Renderer>().material.mainTexture = deactivated;         
        }

    }

    //completely deactivates the button after the coin is collected
    public void finalize(){
        finalized = true;
        this.GetComponent<Renderer>().material.mainTexture = activated;
    }

    
 
}
