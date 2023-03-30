using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame1Manager : MonoBehaviour
{
    [SerializeField] GameObject _button1;
    [SerializeField] GameObject _button2;
    [SerializeField] GameObject _button3;
        [Header("Som")]

    AudioSource newAudio1;
    AudioSource newAudio2;
    AudioSource newAudio3;

    AudioClip audioClip1;
    AudioClip audioClip2;
    AudioClip audioClip3;
    bool boxIsChecked1 = false;
    bool boxIsChecked2 = false;
    bool boxIsChecked3 = false;

    public bool BoxIsChecked1 { get => boxIsChecked1; set => boxIsChecked1 = value; }
    public bool BoxIsChecked2 { get => boxIsChecked2; set => boxIsChecked2 = value; }
    public bool BoxIsChecked3 { get => boxIsChecked3; set => boxIsChecked3 = value; }

    private void Awake()
    {
         newAudio1 = _button1.GetComponent<AudioSource>();
         newAudio2 = _button2.GetComponent<AudioSource>();
         newAudio3 = _button3.GetComponent<AudioSource>();
    }
    public void InfoOnScrene(AudioClip audio1, AudioClip audio2, AudioClip audio3)
    {    
        newAudio1.clip = audio1;     
        audioClip1 = audio1;     
        newAudio2.clip = audio2;
        audioClip2 = audio2;       
        newAudio3.clip = audio3;
        audioClip3 = audio3;
    }

    public void PlaySound1()
    {
        SoundManager.instance.PlayAudioClipSounds(audioClip1);
        //newAudio1.Play();
        //newAudio2.Stop();
        //newAudio3.Stop();
    }
    public void PlaySound2()
    {
        SoundManager.instance.PlayAudioClipSounds(audioClip2);

        //newAudio2.Play();
        //newAudio1.Stop();
        //newAudio3.Stop();
    }
    public void PlaySound3()
    {
        SoundManager.instance.PlayAudioClipSounds(audioClip3);

        //newAudio3.Play();
        //newAudio2.Stop();
        //newAudio1.Stop();
    }

   public void CheckBox1()
    {
        BoxIsChecked1 = true;
        BoxIsChecked2 = false;
        BoxIsChecked3 = false;


    }
    public void CheckBox2()
    {
        BoxIsChecked2 = true;
        BoxIsChecked1 = false;
        BoxIsChecked3 = false;

    }
    public void CheckBox3()
    {
        BoxIsChecked3 = true;
        BoxIsChecked2 = false;
        BoxIsChecked1 = false;
    }
}
