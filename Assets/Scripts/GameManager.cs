using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject pausePanel;

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

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);
        }
    }

    public void LoadScene(int id)
    {
        if (id == 0)
        {
            MusicManager.instance.ChangeMusic(MusicManager.MusicType.menu);
        }
        else if (id == 1)
        {
            MusicManager.instance.ChangeMusic(MusicManager.MusicType.work);
        }

        Time.timeScale = 1.0f;

        SceneManager.LoadScene(id);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
