using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCrystal : MonoBehaviour
{
    public BossAnimations bossAnimations;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void AETingSound()
    {
        bossAnimations.AETingSound();
    }
}
