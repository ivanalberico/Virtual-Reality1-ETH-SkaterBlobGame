using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudioLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }

}
