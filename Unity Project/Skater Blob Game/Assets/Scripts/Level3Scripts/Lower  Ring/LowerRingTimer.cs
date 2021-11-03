using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LowerRingTimer : MonoBehaviour
{
    
    //Script for the display of the timer when puzzle is started

    Text text;
    public LowerRingPuzzleCont cont;
     void Start()
    {
        text = GetComponent<Text>();
    }

    
    void Update()
    {
        text.text = cont.timer.ToString();
    }
}
