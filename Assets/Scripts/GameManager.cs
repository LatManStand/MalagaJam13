using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
