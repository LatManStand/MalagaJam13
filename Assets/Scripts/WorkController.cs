using UnityEngine;

public class WorkController : MonoBehaviour
{
    public bool isActive = false;
    public float efficiencyLossPerSecond = 0.10f;

    private void Update()
    {
        if (isActive)
        {
            GameFlow.instance.currentEfficiency = Mathf.Clamp(GameFlow.instance.currentEfficiency - efficiencyLossPerSecond * Time.deltaTime, GameFlow.minEfficiency, GameFlow.maxEfficiency);
            //GameFlow.instance.currentEfficiency -= efficiencyLossPerSecond * Time.deltaTime;
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
