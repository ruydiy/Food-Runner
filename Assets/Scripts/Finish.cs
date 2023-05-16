using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        GameObject collisionInitiator = collider.gameObject;

        if (collisionInitiator.tag == "Player")
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
