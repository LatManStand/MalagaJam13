using UnityEngine;

public class RelaxController : MonoBehaviour
{
    public bool isActive = false;
    public float efficiencyGainPerSecond = 0.15f;

    private void Update()
    {
        if (isActive)
        {
            GameFlow.instance.currentEfficiency = Mathf.Clamp(GameFlow.instance.currentEfficiency + efficiencyGainPerSecond * Time.deltaTime, GameFlow.minEfficiency, GameFlow.maxEfficiency);
            //GameFlow.instance.currentEfficiency += efficiencyGainPerSecond * Time.deltaTime;
        }
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }
}
