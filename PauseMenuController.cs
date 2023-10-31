using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    // Pause Menu

    public static bool isGamePaused = false;

    private void Start()
    {
        pausedMenu.SetActive(false);
    }

    [Header("Go to Main Menu")]
    public string mainMenu;

    public void mainMenuBtn()
    {
        SceneManager.LoadScene(mainMenu);
    }

    [SerializeField] GameObject pausedMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ContinueGame()
    {
        pausedMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        pausedMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    // Reload level when power runs out
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
