using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject panel;

    public void Toggle()
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
