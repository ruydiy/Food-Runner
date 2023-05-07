using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene("Game");

    public void Options()
    {
        // Options button click logic
    }

    public void Quit() => Application.Quit();
}