using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzlecont : MonoBehaviour
{
    public GameObject SkaterBlob;
    public GameObject lastwall;
    public GameObject firstwall;
    public GameObject door;
    public ColorSection sec1;
    public ColorSection sec2;
    public ColorSection sec3;
    public bool finished;
    public Boost button;
    public PlayerController player;
    public Rigidbody RB;
    

    void Start()
    {
        this.finished = false;
        door.SetActive(false);
        button.pressable = true;
        RB = SkaterBlob.GetComponent<Rigidbody>();
    }

    //completely deactivate the puzzle after the coin is collected 
    public void collected(){
        this.finished = true;
        lastwall.SetActive(false);
        firstwall.SetActive(false);
        door.SetActive(false);
        button.finalized = true;
        sec1.finalize();
        sec2.finalize();
        sec3.finalize();
        player.lvl3Boostreset();
    }

    //starts the puzzle, closes door wall behind, opens the door wall in front,activates the speed boost inthe playercontroller script
    public void startpuzzle(){
        if(!finished){
            button.pressable = false;
            door.SetActive(true);
            firstwall.SetActive(false);
            player.lvl3Boost();
        }
    }
    // resets the puzzle when player failes it, resets blob to start position, resets wall and buttons
    public void resetpuzzle(){
        if(!finished){
            player.lvl3Boostreset();
            SkaterBlob.transform.position = new Vector3(42.41f, 57.576f, -40.33f);
            SkaterBlob.transform.eulerAngles = new Vector3(0f, 22.5f, 0f);
            RB.velocity = Vector3.zero;
            sec1.reset();
            sec2.reset();
            sec3.reset();
            button.pressable = true;
            door.SetActive(false);
            lastwall.SetActive(true);
            firstwall.SetActive(true);
            
        }
    }

}
