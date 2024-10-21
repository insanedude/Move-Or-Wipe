using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusicChange : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider sliderMusic;
    private float _musicVolume;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            _musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }

        if (audioSource != null)
        {
            audioSource.volume = _musicVolume;
        }

        if (sliderMusic != null)
        {
            sliderMusic.value = _musicVolume;
            sliderMusic.onValueChanged.AddListener(ChangingMusicVolume);
        }
    }

    private void Update()
    {
        if (audioSource != null)
        {
            audioSource.volume = _musicVolume;
        }
    }

    public void ChangingMusicVolume(float val)
    {
        _musicVolume = val;
        PlayerPrefs.SetFloat("musicVolume", _musicVolume);

        if (audioSource != null)
        {
            audioSource.volume = _musicVolume;
        }
    }
}


// using System;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class SliderMusicChange : MonoBehaviour
// {
//     [SerializeField] private AudioSource audioSource;
//     [SerializeField] private Slider sliderMusic;
//     private float _musicVolume = PlayerPrefs.GetFloat("musicVolume");
//
//     private void Awake()
//     {
//         if (PlayerPrefs.GetFloat("musicVolume") == 0)
//         {
//             _musicVolume = 0.25f;
//         }
//         else
//         {
//             _musicVolume = PlayerPrefs.GetFloat("musicVolume");
//         }
//     }
//
//     private void Update()
//     {
//         audioSource.volume = _musicVolume;
//     }
//
//     public void ChangingMusicVolume(float val)
//     {
//         _musicVolume = val;
//     }
// }
