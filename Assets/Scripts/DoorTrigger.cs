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

        // Set chunks to quitting so they don't trigger errors
        Chunk[] chunks = GameObject.FindObjectsOfType<Chunk>();
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].isQuitting = true;
        }

        // Fade to black
        _fade.SetTrigger("FadeOut");

        // Load next level
        GameObject.FindObjectOfType<SceneController>().LoadNextLevel();

        _fade.SetTrigger("FadeIn");
    }
}
