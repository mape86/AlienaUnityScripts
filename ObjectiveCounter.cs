
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCounter : MonoBehaviour
{

    public static int objectiveCounter = 0;
    private Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Scan creatures: " + objectiveCounter;
    }
}
