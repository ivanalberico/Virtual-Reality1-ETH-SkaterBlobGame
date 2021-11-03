using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 * Options Menu Script
 * 
 * Author: Ivan Alberico
 * 
 * This script allows you to set the quality and the volume inside the Options Menu.
 * The quality is selected through a Dropdown object, while the volume is regulated
 * through a slider.
 * 
 */
public class OptionsMenu : MonoBehaviour
{
    private void Awake()
    {
        if (GetComponentInChildren<Dropdown>(true) != null)
        {
            GetComponentInChildren<Dropdown>(true).value = QualitySettings.GetQualityLevel();
        }
        if(GetComponentInChildren<Slider>(true) != null && PlayerPrefs.HasKey("volume"))
        {
            GetComponentInChildren<Slider>(true).value = PlayerPrefs.GetFloat("volume");
        }
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
