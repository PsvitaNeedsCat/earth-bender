using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendWater : MonoBehaviour
{
    Renderer rend;

    private float blendVal;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("EarthBender/BlendWater");
    }

    // Update is called once per frame
    void Update()
    {
        blendVal = Mathf.Sin(Time.fixedTime * Mathf.PI * speed) / 2.0f + 0.5f;

        rend.material.SetFloat("_Blend", blendVal);
    }
}
