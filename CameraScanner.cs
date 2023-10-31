using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScanner : MonoBehaviour
{
    public float scan = 1f;
    public float range = 100f;
    public Camera fpsCam;

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Scan();
        }
    }
    //Raycast function
    void Scan()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.getScanned(scan);
            }
        }
    }
}
