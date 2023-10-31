using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScreenShot : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image screenShotDisplayArea;
    [SerializeField] private GameObject screenShotFrame;

    private Texture2D screenCapture;
    private bool viewingScreenShot;
    public CameraChange cameraChange;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        //Checks if the Player is in FirstpersonCamera
        if (cameraChange.CamMode == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (!viewingScreenShot)
                {
                    StartCoroutine(TakeScreenShot());
                }
            }
        }
    }

    IEnumerator TakeScreenShot()
    {
        viewingScreenShot = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        //Shows the screenshot and automatically removes it in 1 sec.
        ShowScreenShot();
        Invoke("RemoveScreenShot", 1f);
    }

    void ShowScreenShot()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        screenShotDisplayArea.sprite = photoSprite;
        screenShotFrame.SetActive(true);
    }

    void RemoveScreenShot()
    {
        viewingScreenShot = false;
        screenShotFrame.SetActive(false);
    }
}
