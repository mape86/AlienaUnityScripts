using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
   private void Update()
   {
    if(Input.GetAxis("Mouse ScrollWheel") > 0)
    {
        GetComponent<Camera>().fieldOfView--;
    }
     if(Input.GetAxis("Mouse ScrollWheel") < 0)
    {
        GetComponent<Camera>().fieldOfView++;
    }
   }
}
