using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseCanvas;
    public GameObject pauseMenuScreen;
    public GameObject controlsScreen;
    public GameObject rulesScreen;
    
    public void PauseToggle()
    {
        isPaused = !isPaused;
        Time.timeScale = Convert.ToSingle(!isPaused);
        this.pauseCanvas.SetActive(isPaused);

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Controls() => this.HideMainMenuAndShowAnotherScreen(this.controlsScreen);

    public void Rules() => this.HideMainMenuAndShowAnotherScreen(this.rulesScreen);

    public void BackToPauseMenuScreen()
    {
        this.controlsScreen.SetActive(false);
        this.rulesScreen.SetActive(false);
        this.pauseMenuScreen.SetActive(true);
    }

    public void Quit() => Application.Quit();

    private void HideMainMenuAndShowAnotherScreen(GameObject otherScreen)
    {
        this.pauseMenuScreen.SetActive(false);
        otherScreen.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && !pauseMenuScreen.activeSelf) 
            {
                this.BackToPauseMenuScreen();
            }
            else
            {
                this.PauseToggle();
            }
        }
    }
}