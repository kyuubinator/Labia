using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameLevel")]
public class ScriptableGame : ScriptableObject
{
    [SerializeField] AudioClip _audioButton1;
    [SerializeField] AudioClip _audioButton2;
    [SerializeField] AudioClip _audioButton3;

    [SerializeField] bool _choice1CheckIfCorrect1;
    [SerializeField] bool _choice1CheckIfCorrect2;
    [SerializeField] bool _choice1CheckIfCorrect3;

   
    [SerializeField] VideoClip _lvlVideo;
    [SerializeField] Sprite _lvlImage;

    public AudioClip AudioButton1 { get => _audioButton1; set => _audioButton1 = value; }
    public AudioClip AudioButton2 { get => _audioButton2; set => _audioButton2 = value; }
    public AudioClip AudioButton3 { get => _audioButton3; set => _audioButton3 = value; }
    public bool Choice1CheckIfCorrect1 { get => _choice1CheckIfCorrect1; set => _choice1CheckIfCorrect1 = value; }
    public bool Choice1CheckIfCorrect2 { get => _choice1CheckIfCorrect2; set => _choice1CheckIfCorrect2 = value; }
    public bool Choice1CheckIfCorrect3 { get => _choice1CheckIfCorrect3; set => _choice1CheckIfCorrect3 = value; }
    public VideoClip LvlVideo { get => _lvlVideo; set => _lvlVideo = value; }
    public Sprite LvlImage { get => _lvlImage; set => _lvlImage = value; }
}
