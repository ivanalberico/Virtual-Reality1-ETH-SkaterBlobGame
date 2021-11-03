using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSection : MonoBehaviour
{
        
    //script for 1 of the 3 section of the color puzzle including 9 buttons and a wall

    public ColorButton L1;
    public ColorButton M1;
    public ColorButton R1;
    public ColorButton L2;
    public ColorButton M2;
    public ColorButton R2;
    public ColorButton L3;
    public ColorButton M3;
    public ColorButton R3;

    public ColorButton C1;
    public ColorButton C2;
    public ColorButton C3;

    public LockWall wall;
    


    void Start()
    {
        
    }

    //Opens the section wall after the correct combination of buttons was pressed and deactive remaining buttons of a 3-set after 1 of them was pressed
    public void puzzle_update(GameObject button){
        if (button == L1.gameObject || button == M1.gameObject || button == R1.gameObject){
            L1.deactivate();
            M1.deactivate();
            R1.deactivate();
        }else if(button == L2.gameObject || button == M2.gameObject || button == R2.gameObject){
            L2.deactivate();
            M2.deactivate();
            R2.deactivate();
        }else if(button == L3.gameObject || button == M3.gameObject || button == R3.gameObject){
            L3.deactivate();
            M3.deactivate();
            R3.deactivate();
        }
        if(C1.pressed && C2.pressed && C3.pressed){
            wall.gameObject.SetActive(false);
        }
        
        
    }
    // completely deactivate all the buttons and the wall of this section (after puzzle is cleared)
    public void finalize(){
        L1.finalize();
        M1.finalize();
        R1.finalize();
        L2.finalize();
        M2.finalize();
        R2.finalize();
        L3.finalize();
        M3.finalize();
        R3.finalize();
        wall.gameObject.SetActive(false);
    }

    // resets the buttons and respawns the wall after the player fails the puzzle
    public void reset(){
        L1.reset();
        M1.reset();
        R1.reset();
        L2.reset();
        M2.reset();
        R2.reset();
        L3.reset();
        M3.reset();
        R3.reset();
        wall.gameObject.SetActive(true);
    }
}
