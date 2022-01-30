using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TotalTime = 180.0f;
    public float currentTime = 0.0f;

    public TextMeshProUGUI text;

    private int hours = 9;
    private int minutes = 0;

    private float relativeness;
    private float relativeTime;

    private void Awake()
    {
        relativeness = 480.0f / TotalTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= TotalTime)
        {
            GameFlow.instance.Lose();
        }

        relativeTime = 540.0f + (currentTime * relativeness);

        hours = (int)relativeTime / 60;
        minutes = (int)relativeTime % 60;

        if (hours >= 16)
        {
            text.color = Color.red;
        }


        if (minutes < 10)
        {
            text.text = hours + ":0" + minutes;
        }
        else
        {
            text.text = hours + ":" + minutes;
        }
    }
}
