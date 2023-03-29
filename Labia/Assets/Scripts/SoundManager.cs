using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject audioSourcePrefab;
    public static SoundManager instance;
    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;

    AudioSource musicAudioSource;
    AudioSource vFXAudioSource;
    AudioSource clipAudioSource;

    float currentVFXVolume = 1;
    float currentMusicVolume = 1;

    public Slider SliderVFXVolume { get => sliderVFXVolume;}
    public Slider SliderMusicVolume { get => sliderMusicVolume;}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
    }
    private void Update()
    {
        if (SliderVFXVolume && SliderMusicVolume)
        {
            currentMusicVolume = SliderMusicVolume.value;
            currentVFXVolume = SliderVFXVolume.value;
            musicAudioSource.volume=currentMusicVolume;
        }
    }
    public void SetVolumeSliders(Slider volumeMusicSlider,Slider volumeVFXSlider)
    {
        sliderVFXVolume = volumeVFXSlider;
        sliderMusicVolume = volumeMusicSlider;
    }
    public void PlayVFXSound(AudioClip audioClip)
    {
        if(!vFXAudioSource)
        {
            GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
            vFXAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
            vFXAudioSource.clip = audioClip;
            vFXAudioSource.volume = currentVFXVolume;
            vFXAudioSource.Play();
            Destroy(audioSourceGameObject, vFXAudioSource.clip.length);

        }
    } 
    public void PlayAudioClipSounds(AudioClip audioClip)
    {
        if(!clipAudioSource)
        {
            GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
            clipAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
            clipAudioSource.clip = audioClip;
            clipAudioSource.volume = currentVFXVolume;
            clipAudioSource.Play();
            Destroy(audioSourceGameObject, clipAudioSource.clip.length);

        }
    }
    public void PlayBackGroundMusic(AudioClip audioClip)
    {
        GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
        musicAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
        musicAudioSource.clip = audioClip;
        musicAudioSource.volume = currentVFXVolume;
        musicAudioSource.loop = true;
        musicAudioSource.Play();

    }
}
