using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EffectsManager : MonoBehaviour
{
    private static EffectsManager _instance;

    public static EffectsManager Instance { get { return _instance; } }

    public string effectsPath;

    private Dictionary<string, GameObject> effectPrefabs;

    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }

        effectPrefabs = new Dictionary<string, GameObject>();
        GameObject[] effects = Resources.LoadAll(effectsPath, typeof(GameObject)).Cast<GameObject>().ToArray();

        for (int i = 0; i < effects.Length; i++)
        {
            effectPrefabs.Add(effects[i].name, effects[i]);
        }
    }

    // Effect name must match prefab file name
    public GameObject SpawnEffect(string effectName)
    {
        GameObject lookUpEffect = effectPrefabs[effectName];

        Debug.Assert(lookUpEffect, "Could not find the specified effect to spawn");

        GameObject newEffect = Instantiate(lookUpEffect, null);
        float duration = newEffect.GetComponent<ParticleSystem>().main.duration;

        GameObject.Destroy(newEffect, duration);
        return newEffect;
    }

}
