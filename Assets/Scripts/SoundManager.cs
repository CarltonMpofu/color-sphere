using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    bool soundOn;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        if(soundOn)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }   
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
    }
}
