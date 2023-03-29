using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void MainMenuSwap(bool value)
    {
        DeactivateMenus();
        mainMenu.SetActive(value);
    }

    public void PauseMenuSwap(bool value)
    {
        pauseMenu.SetActive(value);
        if (value) 
        {
            animMain.SetTrigger("ClickPause");
            animGame.SetTrigger("ClickPause");
        }
    }

    public void GameChoiceMenuSwap(bool value)
    {
        StartCoroutine(DelayGameChoice(value));
    }

    IEnumerator DelayGameChoice(bool value)
    {
        animMain.SetTrigger("ClickPlay");
        yield return new WaitForSeconds(0.5f);
        DeactivateMenus();
        gameChoiceMenu.SetActive(value);
    }

    public void TutorialButton()
    {
        tutorial.Play();
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
