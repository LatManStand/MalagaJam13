using System.Collections;
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

    public MusicType currentType = MusicType.menu;

    public const string MASTER_KEY = "MasterVolume";
    public const string AMBIENT_KEY = "AmbientVolume";
    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SfxVolume";

    public AudioMixer audioMixer;

    public AudioSource menuMusic;
    public AudioSource workMusic;
    public AudioSource relaxMusic;
    public AudioSource workAmbient;
    public AudioSource relaxAmbient;


    public Slider master;
    public Slider ambient;
    public Slider music;
    public Slider sfx;

    public float FadeTime;

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
            instance.master = master;
            instance.ambient = ambient;
            instance.music = music;
            instance.sfx = sfx;

            instance.SetSlidersValues();

            Destroy(gameObject);
        }
    }
    private void Start()
    {
        workMusic.Play();
        workAmbient.Play();
        relaxMusic.Play();
        relaxAmbient.Play();
        workMusic.Pause();
        workAmbient.Pause();
        relaxMusic.Pause();
        relaxAmbient.Pause();
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
        if (musicType != currentType)
        {
            menuMusic.Stop();
            //workMusic.Stop();
            //relaxMusic.Stop();

            switch (musicType)
            {
                case MusicType.menu:
                    menuMusic.Play();
                    break;
                case MusicType.work:
                    StopAllCoroutines();
                    StartCoroutine(nameof(RelaxToWork));
                    //workMusic.Play();
                    break;
                case MusicType.relax:
                    StopAllCoroutines();
                    StartCoroutine(nameof(WorkToRelax));
                    //relaxMusic.Play();
                    break;
            }
            currentType = musicType;
        }
    }

    public IEnumerator RelaxToWork()
    {
        workMusic.volume = 0.0f;
        workMusic.UnPause();
        workAmbient.volume = 0.0f;
        workAmbient.UnPause();
        float remainingTime = FadeTime;
        while (remainingTime >= 0.0f)
        {
            workMusic.volume += Time.deltaTime / (1.0f / FadeTime);
            workAmbient.volume += Time.deltaTime / (1.0f / FadeTime);
            relaxMusic.volume -= Time.deltaTime / (1.0f / FadeTime);
            relaxAmbient.volume -= Time.deltaTime / (1.0f / FadeTime);
            remainingTime -= Time.deltaTime;
            yield return Time.deltaTime;
        }

        workMusic.volume = 1.0f;
        workAmbient.volume = 1.0f;
        relaxMusic.volume = 0.0f;
        relaxAmbient.volume = 0.0f;
        relaxMusic.Pause();
        relaxAmbient.Pause();
    }

    public IEnumerator WorkToRelax()
    {
        relaxMusic.volume = 0.0f;
        relaxAmbient.volume = 0.0f;
        relaxMusic.UnPause();
        relaxAmbient.UnPause();
        float remainingTime = FadeTime;
        while (remainingTime >= 0.0f)
        {
            relaxMusic.volume += Time.deltaTime / (1.0f / FadeTime);
            relaxAmbient.volume += Time.deltaTime / (1.0f / FadeTime);
            workMusic.volume -= Time.deltaTime / (1.0f / FadeTime);
            workAmbient.volume -= Time.deltaTime / (1.0f / FadeTime);
            remainingTime -= Time.deltaTime;
            yield return Time.deltaTime;
        }

        relaxMusic.volume = 1.0f;
        relaxAmbient.volume = 1.0f;
        workMusic.volume = 0.0f;
        workAmbient.volume = 0.0f;
        workMusic.Pause();
        workAmbient.Pause();
    }

    public void StopAll()
    {
        menuMusic.Stop();
        relaxMusic.Stop();
        relaxAmbient.Stop();
        workMusic.Stop();
        workAmbient.Stop();
    }
}
