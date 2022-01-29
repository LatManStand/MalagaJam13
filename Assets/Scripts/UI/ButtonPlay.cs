using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public GameObject panel;
    public void Clicked()
    {
        panel.SetActive(true);
    }
}
