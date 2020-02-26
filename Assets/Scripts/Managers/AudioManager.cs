using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    public SoundEffect[] soundEffects;
    public Dictionary<string, AudioClip> soundDictionary;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        soundDictionary = new Dictionary<string, AudioClip>();

        LoadSounds();
    }

    private void LoadSounds()
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            soundDictionary.Add(soundEffects[i].name, soundEffects[i].clip);
        }
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = soundDictionary[soundName];

        Debug.Assert(clip, "Couldn't find audio clip");

        GameObject soundEffectPlayer = new GameObject("SoundEffectPlayer");
        soundEffectPlayer.transform.parent = this.transform;
        AudioSource audioSource = soundEffectPlayer.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        Destroy(soundEffectPlayer, clip.length);
    }
}
