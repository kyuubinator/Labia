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

    [SerializeField] List<AudioClip> backGroundMusics;


    [SerializeField] AudioClip wrongSound;
    [SerializeField] List<AudioClip> WrightSound;

    [SerializeField] int _positionInGameLevel;


    [Range(0, 1)]
    [SerializeField] float _buttonTransparancy;

    [SerializeField] private AudioClip[] buttonClickClip;
    [SerializeField] private AudioClip[] openPauseMenu;
    [SerializeField] private AudioClip[] backGroundMusic;

    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;

   [SerializeField] Canvas canvas;

    
    public static Game1Manager instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }

    }
    private void Start()
    {
        Shuffle();
        UpdateUI();

        StartCoroutine(PlayBackGroundMusic());
        
    }
    public void Shuffle()
    {
        ScriptableGame tempGO;

        for (int i = 0; i < _gameLevel.Length; i++)
        {
            int rnd = Random.Range(0, _gameLevel.Length);
            tempGO = _gameLevel[rnd];
            _gameLevel[rnd] = _gameLevel[i];
            _gameLevel[i] = tempGO;
        }
        //THX ANTX
    }

    IEnumerator PlayBackGroundMusic()
    {
        sliderMusicVolume.value = SoundManager.instance.CurrentMusicVolume;
        canvas.sortingOrder = -3;
        sliderVFXVolume.value = SoundManager.instance.CurrentVFXVolume;
        SoundManager.instance.SetVolumeSliders(sliderMusicVolume, sliderVFXVolume);
        yield return new WaitUntil(() => SceneManager.sceneCount == 1);
        canvas.sortingOrder = -1;

        AudioClip musicToPlay = backGroundMusic[Random.Range(0, backGroundMusic.Length)];
        SoundManager.instance.PlayBackGroundMusic(musicToPlay, true);
        yield return new WaitForSeconds(musicToPlay.length);
        StartCoroutine(PlayBackGroundMusic());

    }

    void UpdateUI()
    {
      positionInLevel = _gameLevel[_positionInGameLevel]; 
        if(_videoPlayer !=null)
        {
            SoundManager.instance.VPlayer= _videoPlayer;
        }
        audioSource1 = positionInLevel.AudioButton1;
        audioSource2 = positionInLevel.AudioButton2;
        audioSource3 = positionInLevel.AudioButton3;

        _uiManager.InfoOnScrene(audioSource1, audioSource2, audioSource3);

        if (positionInLevel.LvlVideo != null)
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
            SoundManager.instance.PlayVFXSound(WrightSound[Random.Range(0, WrightSound.Count)]);

            _uiManager.CheckButton1.GetComponent<Image>().sprite = _uiManager.CheckCorrectSprite;
            StartCoroutine(WaitToCheck());
        }
      else if(_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect1 == false && _uiManager.BoxIsChecked1 == true)
        {
            SoundManager.instance.PlayVFXSound(wrongSound);

            _uiManager.CheckButton1.GetComponent<Image>().sprite = _uiManager.CheckWrongSprite;
        }
       
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect2 == true && _uiManager.BoxIsChecked2 == true)
        {
            SoundManager.instance.PlayVFXSound(WrightSound[Random.Range(0, WrightSound.Count)]);

            _uiManager.CheckButton2.GetComponent<Image>().sprite = _uiManager.CheckCorrectSprite;
            StartCoroutine(WaitToCheck());
        }
       else if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect2 == false && _uiManager.BoxIsChecked2 == true)
        {
            SoundManager.instance.PlayVFXSound(wrongSound);

            _uiManager.CheckButton2.GetComponent<Image>().sprite = _uiManager.CheckWrongSprite;
        }
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect3 == true && _uiManager.BoxIsChecked3 == true)
        {
            SoundManager.instance.PlayVFXSound(WrightSound[Random.Range(0, WrightSound.Count)]);

            _uiManager.CheckButton3.GetComponent<Image>().sprite = _uiManager.CheckCorrectSprite;

            StartCoroutine(WaitToCheck());
        }
        else if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect3 == false && _uiManager.BoxIsChecked3 == true)
        {
            SoundManager.instance.PlayVFXSound(wrongSound);

            _uiManager.CheckButton3.GetComponent<Image>().sprite = _uiManager.CheckWrongSprite;
        }
    }

    IEnumerator WaitToCheck()
    {
        for (int i = 0; i < _uiManager.InitialButtonsList.Count; i++)
        {
            _uiManager.InitialButtonsList[i].interactable = false;
        }
        yield return new WaitForSeconds(2);
        NextLevel();

    }
    void NextLevel()
    {

        
        _positionInGameLevel++;
        if(_positionInGameLevel>= _gameLevel.Length)
        {
            Debug.Log("2");

            _uiManager.StartChangeScene();
            
        }
        else
        {
            Debug.Log("1");

            UpdateUI();
            for (int i = 0; i < _uiManager.InitialButtonsList.Count; i++)
            {
                _uiManager.InitialButtonsList[i].interactable = true;
            }
            _uiManager.ButtonsList= new List<Button>(_uiManager.InitialButtonsList);
            _uiManager.CheckButton1.GetComponent<Image>().sprite = _uiManager.BlancSprite; 
            _uiManager.CheckButton2.GetComponent<Image>().sprite = _uiManager.BlancSprite; 
            _uiManager.CheckButton3.GetComponent<Image>().sprite = _uiManager.BlancSprite;

        }
    }
    

}
