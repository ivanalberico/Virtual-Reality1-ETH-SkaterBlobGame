using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPuzzleCon : MonoBehaviour
{
    
    public StarButton button1;
    public StarButton button2;
    public StarButton button3;
    public StarButton button4;
    public StarButton button5;
    public CoinL3 coin;

    void Start()
    {
        coin.gameObject.SetActive(false);
    }

    //Implements how buttons are linked and spawns the coin as soon as all buttons are on;
    public void puzzle_update(StarButton curr)
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
            button1.finalize();
            button2.finalize();
            button3.finalize();
            button4.finalize();
            button5.finalize();
            solved();
        }
    }

    public void solved(){
        coin.gameObject.SetActive(true);
    }

    
    void Update()
    {
        
    }
}
