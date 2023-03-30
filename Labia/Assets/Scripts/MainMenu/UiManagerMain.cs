using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    [SerializeField] Image image;
    [SerializeField] float timer;
    [SerializeField] bool startTimer = false;
    [SerializeField] List<GameObject> uiElemenst;
    bool fadeBlack = false;

    private void Start()
    {
        if(SoundManager.instance.SliderMusicVolume)
        {
            sliderVFXVolume.value = SoundManager.instance.SliderVFXVolume.value;
            sliderMusicVolume.value = SoundManager.instance.SliderMusicVolume.value;

        }
        SoundManager.instance.PlayBackGroundMusic(backGroundMusic,false);
        SoundManager.instance.SetVolumeSliders(sliderMusicVolume, sliderVFXVolume);
    }
    private void Update()
    {
        LoadnewScene();
    }

    public void MainMenuSwap(bool value)
    {
        DeactivateMenus();
        mainMenu.SetActive(value);
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

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
        SoundManager.instance.PlayVFXSound(openPauseMenu[Random.Range(0, openPauseMenu.Length)]);
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
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);
        yield return new WaitForSeconds(0.5f);
        DeactivateMenus();
        gameChoiceMenu.SetActive(value);
    }

    public void TutorialButton()
    {
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);
        //tutorial.Play();
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
        SoundManager.instance.PlayVFXSound(buttonClickClip[Random.Range(0, buttonClickClip.Length)]);

        /////////////////////////////////////////////////
        StartCoroutine(ChangeScene(value));
        yield return null;
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
    void LoadnewScene()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (fadeBlack)
            {
                image.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, timer / 1));

                if (image.color.a == 1)
                {
                    startTimer = false;
                    timer = 0f;
                }
            }
            else
            {
                image.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, timer / 1));
                if (image.color.a == 0)
                {
                    startTimer = false;
                    timer = 0f;
                }
            }

        }
    }
    IEnumerator ChangeScene(int value)
    {

        startTimer = true;
        fadeBlack = true;
        Debug.Log("1");
        string sceneName = SceneManager.GetActiveScene().name;
        Destroy(SoundManager.instance.MusicAudioSource.clip=null);


        if (value==0)
        {
            var a = SceneManager.LoadSceneAsync("FirstGame", LoadSceneMode.Additive);
            yield return new WaitUntil(() => a.progress >= 0.9f);
        }
        else
        {
            var a = SceneManager.LoadSceneAsync("FASD", LoadSceneMode.Additive);
            yield return new WaitUntil(() => a.progress >= 0.9f);
            
        }
        

        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < uiElemenst.Count; i++)
        {
            uiElemenst[i].SetActive(false);
        }
        startTimer = true;
        fadeBlack = false;
        yield return new WaitForSeconds(1);
        if (value == 0)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FirstGame"));
            SceneManager.UnloadSceneAsync(sceneName);
        }
        else
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("FASD"));

            SceneManager.UnloadSceneAsync(sceneName);


        }

    }
}
