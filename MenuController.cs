using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    // Main Menu

    [Header("Start new game")]
    public string newGame;

    public void NewGameYes()
    {
        SceneManager.LoadScene(newGame);
        Time.timeScale = 1f;
    }

    [Header("Volume Settings")]
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    [Header("Graphic Settings")]

    private int _qualityLevel;

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
