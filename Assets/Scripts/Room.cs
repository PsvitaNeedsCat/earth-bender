using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Public


    // Private
    GameObject[] levelParts;
    Transform[] initTransforms;

    private void Awake()
    {
        levelParts = new GameObject[transform.childCount];
        initTransforms = new Transform[transform.childCount];

        // Set level parts
        for (int i = 0; i < transform.childCount; i++)
        {
            levelParts[i] = transform.GetChild(i).gameObject;
            initTransforms[i] = levelParts[i].transform;
        }
    }

    public void ResetRoom()
    {
        // Destroy chunks
        Chunk[] chunks = GameObject.FindObjectsOfType<Chunk>();
        for (int i = 0; i < chunks.Length; i++)
        {
            Destroy(chunks[i].gameObject);
        }

        // Reset level parts
        for (int i = 0; i < levelParts.Length; i++)
        {
            // Reset transforms
            levelParts[i].transform.position = initTransforms[i].position;
            levelParts[i].transform.rotation = initTransforms[i].rotation;
            levelParts[i].transform.localScale = initTransforms[i].localScale;

            // Reactivate enemies
            if (levelParts[i].tag == "Enemy")
            {
                levelParts[i].SetActive(true);
            }
        }
    }
}
