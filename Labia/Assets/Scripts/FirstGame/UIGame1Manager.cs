using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    AudioClip audioClip1;
    AudioClip audioClip2;
    AudioClip audioClip3;

    [SerializeField] AudioClip tutorialSound;
    
    bool boxIsChecked1 = false;
    bool boxIsChecked2 = false;
    bool boxIsChecked3 = false;

    [SerializeField] List<Button> buttonsList;
    [SerializeField] List<Button> initialButtonsList;

    [SerializeField] Image image;
    [SerializeField] float timer;
    [SerializeField] bool startTimer = false;
    [SerializeField] List<GameObject> uiElemenst;
    bool fadeBlack = false;
    [SerializeField] Canvas canvas;
    [SerializeField] Slider sliderVFXVolume;
    [SerializeField] Slider sliderMusicVolume;

    public bool BoxIsChecked1 { get => boxIsChecked1; set => boxIsChecked1 = value; }
    public bool BoxIsChecked2 { get => boxIsChecked2; set => boxIsChecked2 = value; }
    public bool BoxIsChecked3 { get => boxIsChecked3; set => boxIsChecked3 = value; }
    public GameObject CheckButton1 { get => _checkButton1; set => _checkButton1 = value; }
    public GameObject CheckButton2 { get => _checkButton2; set => _checkButton2 = value; }
    public GameObject CheckButton3 { get => _checkButton3; set => _checkButton3 = value; }
    public Sprite CheckCorrectSprite { get => _checkCorrectSprite; set => _checkCorrectSprite = value; }
    public Sprite CheckWrongSprite { get => _checkWrongSprite; set => _checkWrongSprite = value; }
    public Sprite BlancSprite { get => _blancSprite; set => _blancSprite = value; }
    public List<Button> InitialButtonsList { get => initialButtonsList; set => initialButtonsList = value; }
    public List<Button> ButtonsList { get => buttonsList; set => buttonsList = value; }


    private void Start()
    {

        InitialButtonsList = new List<Button>(ButtonsList);
    }
    private void Update()
    {
        LoadnewScene();
    }
    public void InfoOnScrene(AudioClip audio1, AudioClip audio2, AudioClip audio3)
    {
     
        audioClip1 = audio1;
        audioClip2 = audio2;       
        audioClip3 = audio3;
    }
    public void TutorialSound()
    {
        SoundManager.instance.PlayAudioClipSounds(tutorialSound);
        ButtonClick();

    }
    public void PlaySound1()
    {

        SoundManager.instance.PlayAudioClipSounds(audioClip1);
        ButtonClick();
    }
    public void PlaySound2()
    {

        SoundManager.instance.PlayAudioClipSounds(audioClip2);
        ButtonClick();
    }
    public void PlaySound3()
    {

        SoundManager.instance.PlayAudioClipSounds(audioClip3);
        ButtonClick();
    }

    public void CheckBox1(Button button)
    {
        button.interactable = false;
        Button buttonSound = _button1.GetComponent<Button>();
        buttonSound.interactable = false;
        _button1.GetComponent<Button>().interactable = false;
        List<Button> newListButtons = new List<Button>();
        for (int i = 0; i < ButtonsList.Count; i++)
        {
            if (ButtonsList[i] == buttonSound)
            {
                ButtonsList.RemoveAt(i);
            }
            if (ButtonsList[i] == button)
            {
                ButtonsList.RemoveAt(i);
            }
            else
            {
                newListButtons.Add(ButtonsList[i]);
            }
        }
        ButtonsList = newListButtons;

        BoxIsChecked1 = true;
        BoxIsChecked2 = false;
        BoxIsChecked3 = false;
        Game1Manager.instance.CheckIfCorrect(); 
    }
    public void CheckBox2(Button button)
    {
        button.interactable = false;
        Button buttonSound = _button2.GetComponent<Button>();
        buttonSound.interactable = false;
        _button2.GetComponent<Button>().interactable = false;
        List<Button> newListButtons = new List<Button>();
        for (int i = 0; i < ButtonsList.Count; i++)
        {
            if (ButtonsList[i] == buttonSound)
            {
                ButtonsList.RemoveAt(i);
            }
            if (ButtonsList[i] == button)
            {
                ButtonsList.RemoveAt(i);
            }
            else
            {
                newListButtons.Add(ButtonsList[i]);
            }
        }
        ButtonsList = newListButtons;
        BoxIsChecked1 = false;
        BoxIsChecked2 = true;
        BoxIsChecked3 = false;
        Game1Manager.instance.CheckIfCorrect();
    }
    public void CheckBox3(Button button)
    {
        button.interactable = false;
        Button buttonSound = _button3.GetComponent<Button>();
        buttonSound.interactable = false;
        _button3.GetComponent<Button>().interactable = false;
        List<Button> newListButtons = new List<Button>();
        for (int i = ButtonsList.Count-1; i >= 0; i--)
        {
          
            if (ButtonsList[i]==button || ButtonsList[i] == buttonSound)
            {
                ButtonsList.RemoveAt(i);
            }
            else
            {
                newListButtons.Add(ButtonsList[i]);
            }
        }
        ButtonsList=newListButtons;

        BoxIsChecked1 = false;
        BoxIsChecked2 = false;
        BoxIsChecked3 = true;

        Game1Manager.instance.CheckIfCorrect();
    }
    private void ButtonClick()
    {
        StartCoroutine(BlockButtons());
    }
    IEnumerator BlockButtons()
    {
        for (int i = 0; i < ButtonsList.Count; i++)
        {
            ButtonsList[i].interactable = false;
        }
        Debug.Log("0");
        yield return new WaitForSeconds(SoundManager.instance.ClipAudioSource.clip.length);
        for (int i = 0; i < ButtonsList.Count; i++)
        {
            Debug.Log("1");
            ButtonsList[i].interactable = true;

        }
        Debug.Log("2");
    }
    public void StartChangeScene()
    {
        StartCoroutine(ChangeScene());
    }
    IEnumerator ChangeScene()
    {

        startTimer = true;
        fadeBlack = true;
        canvas.sortingOrder = 100;
        string sceneName = SceneManager.GetActiveScene().name;
        SoundManager.instance.MusicAudioSource.clip = null;

        var a = SceneManager.LoadSceneAsync("Miguel Copia 2", LoadSceneMode.Additive);
        yield return new WaitUntil(() => a.progress >= 0.9f);



        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < uiElemenst.Count; i++)
        {
            uiElemenst[i].SetActive(false);
        }
        startTimer = true;
        fadeBlack = false;
        yield return new WaitForSeconds(1);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Miguel Copia 2"));
        SceneManager.UnloadSceneAsync(sceneName);

    }
    public void GoTOMainMenu()
    {
        StartCoroutine(ChangeScene());

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
