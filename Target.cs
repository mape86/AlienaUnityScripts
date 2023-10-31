
using UnityEngine;

public class Target : MonoBehaviour
{
    public float targetScanned = 1f;

    public void getScanned(float amount)
    {
        targetScanned -= amount;
        if (targetScanned <= 0f)
        {
            scanObjective();
        }
    }
    void scanObjective()
    {
        ObjectiveCounter.objectiveCounter += 1;
    }
}
