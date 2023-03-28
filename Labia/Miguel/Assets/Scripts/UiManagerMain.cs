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

    bool mainbool;
    bool pausebool;
    bool gameChoiceBool;

    public void MainMenuSwap(bool value)
    {
        DeactivateMenus();
        mainMenu.SetActive(value);
    }

    public void PauseMenuSwap(bool value)
    {
        pauseMenu.SetActive(value);
    }

    public void GameChoiceMenuSwap(bool value)
    {
        DeactivateMenus();
        gameChoiceMenu.SetActive(value);
    }

    public void TutorialButton()
    {
        tutorial.Play();
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
    }
}
