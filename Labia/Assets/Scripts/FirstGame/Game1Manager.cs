using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Game1Manager : MonoBehaviour
{
    [SerializeField] UIGame1Manager _uiManager;

    [SerializeField] ScriptableGame[] _gameLevel;

    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] RawImage _display;
    [SerializeField] RenderTexture _renderTexture;

    ScriptableGame positionInLevel;
    AudioClip audioSource1;
    AudioClip audioSource2;
    AudioClip audioSource3;

    [SerializeField] GameObject Option1;
    [SerializeField] GameObject Option2;
    [SerializeField] GameObject Option3;

    [SerializeField] int _positionInGameLevel;

    Button[] option1;
    Button[] option2;
    Button[] option3;

    [Range(0, 1)]
    [SerializeField] float _buttonTransparancy;

    [SerializeField] private AudioClip[] buttonClickClip;
    [SerializeField] private AudioClip[] openPauseMenu;
    [SerializeField] private AudioClip[] backGroundMusic;

    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;


    [SerializeField] Image image;
    [SerializeField] float timer;
    [SerializeField] bool startTimer = false;
    [SerializeField] List<GameObject> uiElemenst;
    bool fadeBlack = false;



    private void Awake()
    {
        UpdateUI();
         option1 = Option1.GetComponentsInChildren<Button>();
         option2 = Option2.GetComponentsInChildren<Button>();
         option3 = Option3.GetComponentsInChildren<Button>();
    }
    private void Update()
    {
        LoadnewScene();
    }
    IEnumerator PlayBackGroundMusic()
    {
        AudioClip musicToPlay = backGroundMusic[Random.Range(0, backGroundMusic.Length)];
        SoundManager.instance.PlayBackGroundMusic(musicToPlay,true);
        yield return new WaitForSeconds(musicToPlay.length);
        StartCoroutine(PlayBackGroundMusic());

    }

    void UpdateUI()
    {
      positionInLevel = _gameLevel[_positionInGameLevel];

        audioSource1 = positionInLevel.AudioButton1;
        audioSource2 = positionInLevel.AudioButton2;
        audioSource3 = positionInLevel.AudioButton3;

        _uiManager.InfoOnScrene(audioSource1, audioSource2, audioSource3);

        if(positionInLevel.LvlVideo != null)
        {
            _display.texture = _renderTexture;
            _videoPlayer.clip = positionInLevel.LvlVideo;
        }
        else
        {
            _videoPlayer.clip = null;
            _display.texture = positionInLevel.LvlImage.texture;
        }
        


    }

    public void CheckIfCorrect()
    {
      
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect1 == true && _uiManager.BoxIsChecked1 == true)
        {
            NextLevel();
        }
      else if(_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect1 == false && _uiManager.BoxIsChecked1 == true)
        {
           
            foreach (var item in option1)
            {
                item.image.color = new Color(255, 255, 255, _buttonTransparancy);

            }
        }
       
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect2 == true && _uiManager.BoxIsChecked2 == true)
        {
            NextLevel();
        }
       else if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect2 == false && _uiManager.BoxIsChecked2 == true)
        {
           
          
            foreach (var item in option2)
            {
                item.image.color = new Color(255, 255, 255, _buttonTransparancy);

            }
        }
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect3 == true && _uiManager.BoxIsChecked3 == true)
        {
            NextLevel();
        }
        else if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect3 == false && _uiManager.BoxIsChecked3 == true)
        {


            foreach (var item in option3)
            {
                item.image.color = new Color(255, 255, 255, _buttonTransparancy);

            }
        }
    }

    void NextLevel()
    {


        _positionInGameLevel++;
        if(_positionInGameLevel> _gameLevel.Length)
        {
            StartCoroutine(ChangeScene());
            return;
        }
        UpdateUI();

        foreach (var item in option1)
        {
            item.image.color = new Color(255, 255, 255, 1);
        }
        foreach (var item in option2)
        {
            item.image.color = new Color(255, 255, 255, 1);
        }
        foreach (var item in option3)
        {
            item.image.color = new Color(255, 255, 255, 1);
        }
    }
    IEnumerator ChangeScene()
    {

        startTimer = true;
        fadeBlack = true;
        string sceneName = SceneManager.GetActiveScene().name;
        Destroy(SoundManager.instance.MusicAudioSource.clip = null);

        var a = SceneManager.LoadSceneAsync("Miguel Copia 2", LoadSceneMode.Additive);
        yield return new WaitUntil(() => a.progress >= 0.9f);



        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < uiElemenst.Count; i++)
        {
            uiElemenst[i].SetActive(false);
        }
        startTimer = true;
        fadeBlack = false;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Miguel Copia 2"));
        SceneManager.UnloadSceneAsync(sceneName);

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

}
