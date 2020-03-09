using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueEnemy : MonoBehaviour
{
    public TongueCollider tongueCollider;

    public bool isExtending = false;
    public bool isRetracting = false;

    float extendTimer;
    const float maxExtendTimer = 3.0f;

    private void Awake()
    {
        extendTimer = maxExtendTimer;
    }

    public void Swallow()
    {
        isRetracting = false;

        GroundType typeSwallowed = tongueCollider.Swallow();
        Debug.Log("Enemy swallowed: " + typeSwallowed.ToString());

        if (typeSwallowed == GroundType.poison)
        {
            AudioManager.Instance.PlaySoundVaried("RockDestroy");
            Destroy(this.gameObject);
            return;
        }
        else if (typeSwallowed != GroundType.none)
        {
            AudioManager.Instance.PlaySoundVaried("gulp");
        }

        tongueCollider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isExtending && !isRetracting)
        {
            extendTimer -= Time.deltaTime;
            if (extendTimer <= 0.0f)
            {
                extendTimer = maxExtendTimer;
                tongueCollider.gameObject.SetActive(true);
                tongueCollider.Extend();
            }
        }
    }
}
