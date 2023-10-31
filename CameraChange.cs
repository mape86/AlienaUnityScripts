using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdPersonCamera;
    public GameObject FirstPersonCamera;
    public int CamMode;

    void Update()
    {
        //Changes Camera between thirdperson and firstperson
        if(Input.GetButtonDown ("Camera"))
        {
            if(CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }
    //Deactivates previous camera used
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            ThirdPersonCamera.SetActive(true);
            FirstPersonCamera.SetActive(false);
        }
        if(CamMode == 1)
        {
            FirstPersonCamera.SetActive(true);
            ThirdPersonCamera.SetActive(false);
        }
    }
}
