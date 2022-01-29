using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public enum MusicType
    {
        menu,
        work,
        relax
    }

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
            SetSlidersValues();
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetSlidersValues()
    {
        master.value = PlayerPrefs.GetFloat(MASTER_KEY, 1.0f);
        ambient.value = PlayerPrefs.GetFloat(AMBIENT_KEY, 1.0f);
        music.value = PlayerPrefs.GetFloat(MUSIC_KEY, 1.0f);
        sfx.value = PlayerPrefs.GetFloat(SFX_KEY, 1.0f);


        audioMixer.SetFloat(MASTER_KEY, Mathf.Log10(master.value) * 20);
        audioMixer.SetFloat(AMBIENT_KEY, Mathf.Log10(ambient.value) * 20);
        audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(music.value) * 20);
        audioMixer.SetFloat(SFX_KEY, Mathf.Log10(sfx.value) * 20);
    }

    public void ChangeVolume(SoundSlider.MixerType mixerType, float ammount)
    {
        switch (mixerType)
        {
            case SoundSlider.MixerType.Master:
                audioMixer.SetFloat(MASTER_KEY, Mathf.Log10(ammount) * 20);
                PlayerPrefs.SetFloat(MASTER_KEY, ammount);
                break;
            case SoundSlider.MixerType.Ambient:
                audioMixer.SetFloat(AMBIENT_KEY, Mathf.Log10(ammount) * 20);
                PlayerPrefs.SetFloat(AMBIENT_KEY, ammount);
                break;
            case SoundSlider.MixerType.Music:
                audioMixer.SetFloat(MUSIC_KEY, Mathf.Log10(ammount) * 20);
                PlayerPrefs.SetFloat(MUSIC_KEY, ammount);
                break;
            case SoundSlider.MixerType.SFX:
                audioMixer.SetFloat(SFX_KEY, Mathf.Log10(ammount) * 20);
                PlayerPrefs.SetFloat(SFX_KEY, ammount);
                break;
        }
    }

    public void ChangeMusic(MusicType musicType)
    {
        menuMusic.Pause();
        workMusic.Pause();
        relaxMusic.Pause();

        switch (musicType)
        {
            case MusicType.menu:
                menuMusic.Play();
                break;
            case MusicType.work:
                workMusic.Play();
                break;
            case MusicType.relax:
                relaxMusic.Play();
                break;
        }
    }
}
