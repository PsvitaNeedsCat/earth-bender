using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Play()
    {
        SceneController.DestroyInstance();

        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Debug.Log("Qutting...");

        Application.Quit();
    }
}
