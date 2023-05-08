using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene("Game");

    public void Rules()
    {
        // Rules button click logic
    }

    public void Quit() => Application.Quit();
}