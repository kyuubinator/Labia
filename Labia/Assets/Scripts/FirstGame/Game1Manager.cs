using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    [SerializeField] UIGame1Manager _uiManager;

    [SerializeField] ScriptableGame[] _gameLevel;

    ScriptableGame _positionInLevel;
    AudioClip _audioSource1;
    AudioClip _audioSource2;
    AudioClip _audioSource3;

    [SerializeField] int _positionInGameLevel;

    bool boxIsChecked1 = false;
    bool boxIsChecked2 = false;
    bool boxIsChecked3 = false;
    private void Awake()
    {
        UpdateUI();

    }
    
    void UpdateUI()
    {
      _positionInLevel = _gameLevel[_positionInGameLevel];

        _audioSource1 = _positionInLevel.AudioButton1;
        _audioSource2 = _positionInLevel.AudioButton2;
        _audioSource3 = _positionInLevel.AudioButton3;

        _uiManager.InfoOnScrene(_audioSource1, _audioSource2, _audioSource3);


    }

    public void CheckIfCorrect()
    {
        if(_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect1 == true && boxIsChecked1 == true)
        {
            _positionInGameLevel++;
            UpdateUI();
        }
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect2 == true && boxIsChecked2 == true)
        {
            _positionInGameLevel++;
            UpdateUI();
        }
        if (_gameLevel[_positionInGameLevel].Choice1CheckIfCorrect3 == true && boxIsChecked3 == true)
        {
            _positionInGameLevel++;
            UpdateUI();
        }
    }

    public void CheckBox1Imp()
    {
       CheckBox1();
    }
    public void CheckBox2Imp()
    {
        CheckBox2();
    }
    public void CheckBox3Imp()
    {
        CheckBox3();
    }

    void CheckBox1()
    {
            boxIsChecked1 = true;
        boxIsChecked2 = false;
        boxIsChecked3 = false;
    }
    void CheckBox2()
    {    
            boxIsChecked2 = true;
        boxIsChecked1 = false;
        boxIsChecked3 = false;

    }
     void CheckBox3()
    {      
            boxIsChecked3 = true;
        boxIsChecked2 = false;
        boxIsChecked1 = false;
    }
}
