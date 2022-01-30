using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    public Slider efficiency;
    public Image efficiencyFill;
    public Slider work;

    public Sprite green;
    public Sprite red;

    public AudioSource soft;
    public AudioSource hard;

    private void Awake()
    {
        efficiency.minValue = GameFlow.minEfficiency;
        efficiency.maxValue = GameFlow.maxEfficiency;
        efficiency.value = GameFlow.maxEfficiency;
        work.maxValue = GameFlow.workToDo;
        work.value = 0.0f;
        soft.Play();
        hard.Play();
        soft.Pause();
        hard.Pause();
    }

    void Update()
    {
        if (!hard.isPlaying && efficiency.value <= 0.25)
        {
            hard.UnPause();
        }
        else if (!soft.isPlaying && efficiency.value <= 0.5)
        {
            soft.UnPause();
        }


        if (efficiencyFill.sprite == green && efficiency.value <= 0.5)
        {
            efficiencyFill.sprite = red;
        }
        else if (efficiencyFill.sprite == red && efficiency.value >= 0.5)
        {
            efficiencyFill.sprite = green;
        }
        efficiency.value = GameFlow.instance.currentEfficiency;
        work.value = GameFlow.instance.workDone;
    }
}
