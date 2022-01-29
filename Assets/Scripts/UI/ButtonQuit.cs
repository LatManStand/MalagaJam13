using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }
}
