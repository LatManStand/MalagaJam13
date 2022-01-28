using UnityEngine;

public class WorkController : MonoBehaviour
{
    public bool isActive = false;
    public float efficiencyLossPerSecond = 0.05f;

    private void Update()
    {
        if (isActive)
        {
            GameFlow.instance.currentEfficiency -= efficiencyLossPerSecond * Time.deltaTime;
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
