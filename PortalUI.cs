
using UnityEngine;

public class PortalUI : MonoBehaviour
{

    public GameObject portalBlockedUI;
    public GameObject returnHomeUI;
    private int numOfSpheres;

    void Start()
    {
        portalBlockedUI.SetActive(false);
        returnHomeUI.SetActive(false);
    }

    void Update()
    {
        numOfSpheres = GameObject.FindGameObjectsWithTag("ActivatedSphere").Length;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player") && numOfSpheres != 3)
        {
            portalBlockedUI.SetActive(true);
            Invoke("RemovePortalBlockedUI", 3f);
        }
        else
        {
            returnHomeUI.SetActive(true);
        }
    }

    private void RemovePortalBlockedUI()
    {
        portalBlockedUI.SetActive(false);
    }
}
