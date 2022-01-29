using UnityEngine;

public class ButtonMusic : MonoBehaviour
{
    public GameObject sliders;
    public GameObject buttons;

    public void Clicked()
    {
        if (buttons.activeInHierarchy)
        {
            buttons.SetActive(false);
            sliders.SetActive(true);
        } else
        {
            sliders.SetActive(false);
            buttons.SetActive(true);
        }
    }
}
