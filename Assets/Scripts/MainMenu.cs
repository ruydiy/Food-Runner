using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject controlsScreen;
    public GameObject rulesScreen;

    public void Play() => SceneManager.LoadScene("Game");

    public void Controls() => this.HideMainMenuAndShowAnotherScreen(this.controlsScreen);

    public void Rules() => this.HideMainMenuAndShowAnotherScreen(this.rulesScreen);

    public void BackToMainMenuScreen()
    {
        this.controlsScreen.SetActive(false);
        this.rulesScreen.SetActive(false);
        this.mainMenuScreen.SetActive(true);
    }

    public void Quit() => Application.Quit();

    private void HideMainMenuAndShowAnotherScreen(GameObject otherScreen)
    {
        this.mainMenuScreen.SetActive(false);
        otherScreen.SetActive(true);
    }

    private void Update()
    {
        if (!this.mainMenuScreen.activeSelf && Input.GetKey(KeyCode.Escape))
        {
            this.BackToMainMenuScreen();
        }
    }
}