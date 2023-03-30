using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame1Manager : MonoBehaviour
{
    [Header("Sound Buttons")]
    [SerializeField] GameObject _button1;
    [SerializeField] GameObject _button2;
    [SerializeField] GameObject _button3;

    [Header("Check Buttons")]

    [SerializeField] GameObject _checkButton1;
    [SerializeField] GameObject _checkButton2;
    [SerializeField] GameObject _checkButton3;

    [SerializeField] Sprite _checkCorrectSprite;
    [SerializeField] Sprite _checkWrongSprite;
    [SerializeField] Sprite _blancSprite;

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
    public GameObject CheckButton1 { get => _checkButton1; set => _checkButton1 = value; }
    public GameObject CheckButton2 { get => _checkButton2; set => _checkButton2 = value; }
    public GameObject CheckButton3 { get => _checkButton3; set => _checkButton3 = value; }
    public Sprite CheckCorrectSprite { get => _checkCorrectSprite; set => _checkCorrectSprite = value; }
    public Sprite CheckWrongSprite { get => _checkWrongSprite; set => _checkWrongSprite = value; }
    public Sprite BlancSprite { get => _blancSprite; set => _blancSprite = value; }

    private void Awake()
    {
         newAudio1 = _button1.GetComponent<AudioSource>();
         newAudio2 = _button2.GetComponent<AudioSource>();
         newAudio3 = _button3.GetComponent<AudioSource>();
    }
    public void InfoOnScrene(AudioClip audio1, AudioClip audio2, AudioClip audio3)
    {
     
        audioClip1 = audio1;
        audioClip2 = audio2;       
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
        Game1Manager.instance.CheckIfCorrect(); 




    }
    public void CheckBox2()
    {        
        BoxIsChecked2 = true;
        BoxIsChecked1 = false;
        BoxIsChecked3 = false;
        Game1Manager.instance.CheckIfCorrect();


    }
    public void CheckBox3()
    {

        BoxIsChecked3 = true;
        BoxIsChecked2 = false;
        BoxIsChecked1 = false;
        Game1Manager.instance.CheckIfCorrect();
    }

   
}
