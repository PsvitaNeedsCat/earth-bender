using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }

    public string soundEffectsPath;

    private Dictionary<string, AudioClip> soundDictionary;

    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }

        soundDictionary = new Dictionary<string, AudioClip>();
        AudioClip[] audioClips = Resources.LoadAll(soundEffectsPath, typeof(AudioClip)).Cast<AudioClip>().ToArray();

        for (int i = 0; i < audioClips.Length; i++)
        {
            soundDictionary.Add(audioClips[i].name, audioClips[i]);
        }
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = soundDictionary[soundName];

        Debug.Assert(clip, "Couldn't find audio clip");

        GameObject soundEffectPlayer = new GameObject("SoundEffectPlayer");
        if (soundEffectPlayer)
        {
            soundEffectPlayer.transform.parent = this.transform;
            AudioSource audioSource = soundEffectPlayer.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip);
            Destroy(soundEffectPlayer, clip.length);
        }
    }

    public void PlaySoundVaried(string soundName)
    {
        AudioClip clip = soundDictionary[soundName];

        Debug.Assert(clip, "Couldn't find audio clip");

        GameObject soundEffectPlayer = new GameObject("SoundEffectPlayer");
        if (soundEffectPlayer)
        {
            soundEffectPlayer.transform.parent = this.transform;
            AudioSource audioSource = soundEffectPlayer.AddComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.volume = Random.Range(0.8f, 1.0f);
            audioSource.PlayOneShot(clip);
            Destroy(soundEffectPlayer, clip.length);
        }
    }
}
