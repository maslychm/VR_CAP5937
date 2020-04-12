using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLaptopAudio : MonoBehaviour
{
    AudioSource ac;

    void Start()
    {
        ac = GameObject.Find("Laptop_On").GetComponent<AudioSource>();
    }

    public void Pa()
    {
        if (ac.isPlaying)
            ac.Pause();
        else
            ac.Play();
    }
}
