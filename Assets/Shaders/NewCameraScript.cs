using UnityEngine;

[ExecuteInEditMode]
public class NewCameraScript : MonoBehaviour
{

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
    }

}