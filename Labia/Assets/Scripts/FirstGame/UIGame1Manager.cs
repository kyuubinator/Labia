using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame1Manager : MonoBehaviour
{
    [SerializeField] GameObject _button1;
    [SerializeField] GameObject _button2;
    [SerializeField] GameObject _button3;

    AudioSource newAudio1;
    AudioSource newAudio2;
    AudioSource newAudio3;
    private void Awake()
    {
         newAudio1 = _button1.GetComponent<AudioSource>();
         newAudio2 = _button2.GetComponent<AudioSource>();
         newAudio3 = _button3.GetComponent<AudioSource>();
    }
    public void InfoOnScrene(AudioClip audio1, AudioClip audio2, AudioClip audio3)
    {    
        newAudio1.clip = audio1;     
        newAudio2.clip = audio2;       
        newAudio3.clip = audio3;
    }

    public void PlaySound1()
    {
        newAudio1.Play();
        newAudio2.Stop();
        newAudio3.Stop();
    }
    public void PlaySound2()
    {
        newAudio2.Play();
        newAudio1.Stop();
        newAudio3.Stop();
    }
    public void PlaySound3()
    {
        newAudio3.Play();
        newAudio2.Stop();
        newAudio1.Stop();
    }
}
