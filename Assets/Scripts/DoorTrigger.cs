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

        // Fade to black
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeOut");

        StartCoroutine(LoadNextLevel());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeOut");
        }
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1.0f);

        // Set chunks to quitting so they don't trigger errors
        Chunk[] chunks = GameObject.FindObjectsOfType<Chunk>();
        for (int i = 0; i < chunks.Length; i++)
        {
            chunks[i].isQuitting = true;
        }

        // Load next level
        GameObject.FindObjectOfType<SceneController>().LoadNextLevel();
    }
}
