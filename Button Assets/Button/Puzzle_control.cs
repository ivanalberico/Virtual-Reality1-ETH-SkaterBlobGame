using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_control : MonoBehaviour
{	
	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void puzzle_update(Button curr)
    {	
    	if(curr == button1){
    		button3.button_press();
    		button4.button_press();
    	}else if(curr == button2){
    		button4.button_press();
    		button5.button_press();
    	}else if(curr == button3){
    		button1.button_press();
    		button5.button_press();
    	} else if(curr == button4){
    		button1.button_press();
    		button2.button_press();
    	} else if(curr == button5){
    		button2.button_press();
    		button3.button_press();
    	}

    	if(button1.pressed && button2.pressed && button3.pressed && button4.pressed && button5.pressed){
    		button1.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
    		button2.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
    		button3.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
    		button4.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
    		button5.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
    		button1.finalized = true;
    		button2.finalized = true;
    		button3.finalized = true;
    		button4.finalized = true;
    		button5.finalized = true;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
