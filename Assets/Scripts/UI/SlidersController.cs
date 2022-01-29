using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    public Slider efficiency;
    public Slider work;

    private void Awake()
    {
        efficiency.minValue = GameFlow.minEfficiency;
        efficiency.maxValue = GameFlow.maxEfficiency;
        efficiency.value = GameFlow.maxEfficiency;
        work.maxValue = GameFlow.workToDo;
        work.value = 0.0f;
    }

    void Update()
    {
        efficiency.value = GameFlow.instance.currentEfficiency;
        work.value = GameFlow.instance.workDone;
    }
}
