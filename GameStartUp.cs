
using UnityEngine;

public class GameStartUp : MonoBehaviour
{
    public GameObject startUpUI;
    public GameObject allSpheresActivatedUI;
    private int numOfActivatedSpheres;
    private int runTime;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        startUpUI.SetActive(true);
        Invoke("RemoveStartUpUI", 3f);
        runTime = 0;

        allSpheresActivatedUI.SetActive(false);
    }

    private void Update()
    {
        numOfActivatedSpheres = GameObject.FindGameObjectsWithTag("ActivatedSphere").Length;

        if (numOfActivatedSpheres == 3 && runTime == 0)
        {
            allSpheresActivatedUI.SetActive(true);
            Invoke("RemoveAllSpheresUI", 5f);
            runTime++;
        }
    }

    private void RemoveStartUpUI()
    {
        startUpUI.SetActive(false);
    }

    private void RemoveAllSpheresUI()
    {
        allSpheresActivatedUI.SetActive(false);
    }



}
