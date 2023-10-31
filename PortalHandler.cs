
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    private int activtatedSpheres;

    void Update()
    {
        HandleBlocked();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Portal":
                StartChangeLevelSequence();
                break;
            case "Blocked":
                print("All spheres must be activated to open the portal. You have activated " + activtatedSpheres + " of 3 spheres.");
                break;
            default:
                break;
        }
    }

    void StartChangeLevelSequence()
    {
        GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        NextLevel();
    }

    //Method handling changing level. If the current level is the last one, it will load the first level.
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    //Method handling the blocked portal. If all spheres are activated, the portal will be unblocked.
    void HandleBlocked()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 2)
        {
            activtatedSpheres = GameObject.FindGameObjectsWithTag("ActivatedSphere").Length;
            if (activtatedSpheres == 3)
            {
                if (GameObject.FindGameObjectWithTag("Blocked"))
                {
                    GameObject.FindGameObjectWithTag("Blocked").tag = "Portal";
                }
            }
        }
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
