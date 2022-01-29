using UnityEngine;

public class ButtonSceneLoader : MonoBehaviour
{
    public int sceneToLoad = 0;

    public void Clicked()
    {
        GameManager.instance.LoadScene(sceneToLoad);
    }
}
