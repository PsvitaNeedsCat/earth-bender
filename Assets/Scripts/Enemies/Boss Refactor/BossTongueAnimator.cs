using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTongueAnimator : MonoBehaviour
{
    public BossTongueCollider tongueCollider;

    public void OnRetracted()
    {
        tongueCollider.OnRetracted();
    }
}
