using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerMain : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameChoiceMenu;
    [SerializeField] private AudioSource tutorial;
    [SerializeField] private GameObject[] gameSelected;
    
    [SerializeField] private AudioClip[] buttonClickClip;
    [SerializeField] private AudioClip[] openPauseMenu;
    [SerializeField] private AudioClip backGroundMusic;

    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;



    bool mainbool;
    bool pausebool;
    bool gameChoiceBool;

    private void Start()
    {
        //ISTO TA MAl
        sliderVFXVolume.value = SoundManager.instance.SliderVFXVolume.value;
        sliderMusicVolume.value = SoundManager.instance.SliderMusicVolume.value;
        SoundManager.instance.PlayBackGroundMusic(backGroundMusic);
        SoundManager.instance.SetVolumeSliders(sliderMusicVolume, sliderVFXVolume);
    }
    public void MainMenuSwap(bool value)
    {
        DeactivateMenus();
        mainMenu.SetActive(value);
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

    }

    public void PauseMenuSwap(bool value)
    {
        pauseMenu.SetActive(value);
        SoundManager.instance.PlayVFXSound(openPauseMenu[Random.Range(0, openPauseMenu.Length)]);
    }

    public void GameChoiceMenuSwap(bool value)
    {
        DeactivateMenus();
        gameChoiceMenu.SetActive(value);
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

    }

    public void TutorialButton()
    {
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

        //tutorial.Play();
    }

    public void DeactivateMenus()
    {
        mainMenu?.SetActive(false);
        pauseMenu?.SetActive(false);
        gameChoiceMenu?.SetActive(false);
    }

    public void GameSelected(int value)
    {
        gameSelected[value].SetActive(true);
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

    }
}
