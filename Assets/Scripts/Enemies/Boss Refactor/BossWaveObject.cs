using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaveObject : MonoBehaviour
{
    public void OnWaveStart()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void OnWaveEnd()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
