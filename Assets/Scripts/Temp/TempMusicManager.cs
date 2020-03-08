using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMusicManager : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField] AudioClip bossMusic;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayBossMusic()
    {
        _audioSource.Stop();
        _audioSource.clip = bossMusic;
        _audioSource.Play();
    }
}
