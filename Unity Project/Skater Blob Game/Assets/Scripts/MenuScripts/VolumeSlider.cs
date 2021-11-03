using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Volume Slider Script
 * 
 * Author: Ivan Alberico
 * 
 * This script is implemented in order to create the connection between the audio source and the slider in the Options menu
 * 
 */
public class VolumeSlider : MonoBehaviour
{
    public AudioSource AudioSource;


    public void updateVolume(float volume)
    {
        AudioSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

}
