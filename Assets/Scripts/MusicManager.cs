using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public const string MASTER_KEY = "MasterVolume";
    public const string AMBIENT_KEY = "AmbientVolume";
    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SfxVolume";

    public AudioMixer audioMixer;

    public AudioSource menuMusic;
    public AudioSource workMusic;
    public AudioSource relaxMusic;


    public Slider master;
    public Slider ambient;
    public Slider music;
    public Slider sfx;

    public static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeVolume(SoundSlider.MixerType mixerType, float ammount)
    {
        switch (mixerType)
        {
            case SoundSlider.MixerType.Master:
                audioMixer.SetFloat(MASTER_KEY, Mathf.Log10(ammount) * 20);
                break;
            case SoundSlider.MixerType.Ambient:
                audioMixer.SetFloat(AMBIENT_KEY, Mathf.Log10(ammount) * 20);
                break;
            case SoundSlider.MixerType.Music:
                audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(ammount) * 20);
                break;
            case SoundSlider.MixerType.SFX:
                audioMixer.SetFloat(SFX_KEY, Mathf.Log10(ammount) * 20);
                break;
        }
    }

    public void ChangeMusic()
    {

    }
}
