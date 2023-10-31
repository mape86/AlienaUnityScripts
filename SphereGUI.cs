
using UnityEngine;
using UnityEngine.UI;

public class SphereGUI : MonoBehaviour
{

    public string displayText;
    public Text textElement;
    private int numOfActivatedSpheres;

    void Start()
    {
        textElement.text = displayText;
    }

    void Update()
    {
        numOfActivatedSpheres = GameObject.FindGameObjectsWithTag("ActivatedSphere").Length;
        textElement.text = numOfActivatedSpheres + "/3 Spheres Activated";

    }
}
