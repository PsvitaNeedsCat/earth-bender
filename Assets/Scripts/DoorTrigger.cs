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

        Player _player = GameObject.FindObjectOfType<Player>();
        Animator _fade = GameObject.Find("Fade").GetComponent<Animator>();

        // Remove controls
        _player.SetControls(false);

        // Make player kinematic
        _player.GetComponent<Rigidbody>().isKinematic = true;

        // Fade to black
        _fade.SetTrigger("FadeOut");

        // Load next level
        GameObject.FindObjectOfType<SceneController>().LoadNextLevel();

        // Move player position
        SpawnPosition[] spawnPositions = GameObject.FindObjectsOfType<SpawnPosition>();
        if (spawnPositions.Length == 1) { _player.transform.position = spawnPositions[0].transform.position; }
        else
        {
            int highestLevel = 0;
            int index = -1;
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                if (spawnPositions[i].level > highestLevel) { highestLevel = spawnPositions[i].level; index = i; }
            }

            _player.transform.position = spawnPositions[index].transform.position;
        }

        // Make player non-kinematic
        _player.GetComponent<Rigidbody>().isKinematic = false;

        // Give player control again
        _player.SetControls(true);

        _fade.SetTrigger("FadeIn");
    }
}
