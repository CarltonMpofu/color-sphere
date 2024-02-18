using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    bool soundOn;

    AudioSource audioSource;

    [SerializeField] Image soundButtonImage;

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
        if(soundOn)
        {
            soundOn = false;
            soundButtonImage.color = Color.red;
        }
        else
        {
            soundOn = true;
            soundButtonImage.color = Color.white;
        }
    }
}
