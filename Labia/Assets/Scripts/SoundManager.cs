using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject audioSourcePrefab;
    public static SoundManager instance;
    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;

    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource vFXAudioSource;
    [SerializeField] AudioSource clipAudioSource;
    [SerializeField] VideoPlayer vPlayer;

    [SerializeField] float currentVFXVolume = 1;
    [SerializeField] float currentMusicVolume = 1;

    public Slider SliderVFXVolume { get => sliderVFXVolume;}
    public Slider SliderMusicVolume { get => sliderMusicVolume;}
    public AudioSource MusicAudioSource { get => musicAudioSource; set => musicAudioSource = value; }
    public AudioSource ClipAudioSource { get => clipAudioSource; set => clipAudioSource = value; }
    public float CurrentVFXVolume { get => currentVFXVolume; set => currentVFXVolume = value; }
    public float CurrentMusicVolume { get => currentMusicVolume; set => currentMusicVolume = value; }
    public VideoPlayer VPlayer { get => vPlayer; set => vPlayer = value; }

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
            CurrentMusicVolume = SliderMusicVolume.value;
            CurrentVFXVolume = SliderVFXVolume.value;
            if(MusicAudioSource!=null)
            {
               
                MusicAudioSource.volume=CurrentMusicVolume;
            }
            if(VPlayer!=null)
            {
                VPlayer.SetDirectAudioVolume(0,currentVFXVolume);
            }
        }
    }
    public void SetVolumeSliders(Slider volumeMusicSlider,Slider volumeVFXSlider)
    {
        sliderVFXVolume = volumeVFXSlider;
        sliderMusicVolume = volumeMusicSlider;
    }
    public void PlayVFXSound(AudioClip audioClip)
    {
       
            GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
            vFXAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
            vFXAudioSource.clip = audioClip;
            vFXAudioSource.volume = CurrentVFXVolume;
            vFXAudioSource.Play();
            Destroy(audioSourceGameObject, vFXAudioSource.clip.length);

        
    } 
    public void PlayAudioClipSounds(AudioClip audioClip)
    {
        if(!ClipAudioSource)
        {
            GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
            ClipAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
            ClipAudioSource.clip = audioClip;
            ClipAudioSource.volume = CurrentVFXVolume;
            ClipAudioSource.Play();
            Destroy(audioSourceGameObject, ClipAudioSource.clip.length);

        }
    }
    public void PlayBackGroundMusic(AudioClip audioClip, bool destroy)
    {
        GameObject audioSourceGameObject = Instantiate(audioSourcePrefab);
        MusicAudioSource = audioSourceGameObject.GetComponent<AudioSource>();
        MusicAudioSource.clip = audioClip;
        MusicAudioSource.volume = CurrentVFXVolume;
        MusicAudioSource.loop = true;
        MusicAudioSource.Play();
        if (destroy)
        {
            Destroy(audioSourceGameObject, MusicAudioSource.clip.length);
        }
    }
 

}
