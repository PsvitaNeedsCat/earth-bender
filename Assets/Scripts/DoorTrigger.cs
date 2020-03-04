using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) { return; }
        triggered = true;

        Animator _fade = GameObject.Find("Fade").GetComponent<Animator>();

        // Fade to black
        _fade.SetTrigger("FadeOut");

        // Load next level
        GameObject.FindObjectOfType<SceneController>().LoadNextLevel();

        _fade.SetTrigger("FadeIn");
    }
}
