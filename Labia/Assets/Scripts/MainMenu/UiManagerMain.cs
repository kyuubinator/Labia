using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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

    [SerializeField] private Animator animMain;
    [SerializeField] private Animator animPause;
    [SerializeField] private Animator animGame;

    [Header("Som")]
    [SerializeField] private AudioClip[] buttonClickClip;
    [SerializeField] private AudioClip[] openPauseMenu;
    [SerializeField] private AudioClip backGroundMusic;

    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;

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
        //SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

    }

    public void PauseMenuSwap(bool value)
    {
        if (value == false)
        {
            StartCoroutine(PauseAnimation());
        }
        else
        {
            pauseMenu.SetActive(true);
        }
        //SoundManager.instance.PlayVFXSound(openPauseMenu[Random.Range(0, openPauseMenu.Length)]);
        if (value) 
        {
            animMain.SetTrigger("ClickPause");
            animGame.SetTrigger("ClickPause");
        }
    }

    IEnumerator PauseAnimation()
    {
        animPause.SetTrigger("ClosePause");
        yield return new WaitForSeconds(0.66f);
        pauseMenu.SetActive(false);
    }

    public void GameChoiceMenuSwap(bool value)
    {
        StartCoroutine(DelayGameChoice(value));
    }

    IEnumerator DelayGameChoice(bool value)
    {
        animMain.SetTrigger("ClickPlay");
        //SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);
        yield return new WaitForSeconds(0.5f);
        DeactivateMenus();
        gameChoiceMenu.SetActive(value);
    }

    public void TutorialButton()
    {
        //SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);
        ////tutorial.Play();
        animMain.SetTrigger("ClickTutorial");
        animGame.SetTrigger("ClickTutorial");
    }

    public void DeactivateMenus()
    {
        mainMenu?.SetActive(false);
        pauseMenu?.SetActive(false);
        gameChoiceMenu?.SetActive(false);
    }

    public void GameSelected(int value)
    {
        StartCoroutine(DelayGameMode(value));
    }

    IEnumerator DelayGameMode(int value)
    {
        //SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);
        yield return new WaitForSeconds(0.5f);
        gameSelected[value].SetActive(true);
    }

    public void GameChoice1(bool value)
    {
        if (value)
        {
            animGame.SetTrigger("ClickGame1");
        }
        else
        {
            animGame.SetTrigger("ClickGame2");
        }
    }
}
