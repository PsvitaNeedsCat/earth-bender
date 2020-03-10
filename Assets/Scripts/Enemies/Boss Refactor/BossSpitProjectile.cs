using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitProjectile : MonoBehaviour
{
    [HideInInspector] public bool isFragment = false;
    [HideInInspector] public bool rockEaten = false;
    [HideInInspector] public GridTile aimedTile;
    [HideInInspector] public BossSpitUpAttack spitUpAttack;
    [HideInInspector] public Rigidbody rigidBody;
    public GameObject hurtboxPrefab;
    [HideInInspector] public List<GameObject> aimIndicators;
    public GameObject dropShadow;
    public float dropShadowMaxRange = 50.0f;
    public LayerMask dropShadowMask = -1;
    public float dropShadowMinScale = 0.01f;
    public float dropShadowMaxScale = 0.1f;


    private static Vector3[] fragmentDirections = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
    private bool isQuitting = false;

    // Despawn fragments
    float fragmentTimer = 3.0f;
    bool outOfZone = false;

    private void Update()
    {
        if (isFragment)
        {
            fragmentTimer -= Time.deltaTime;
            if (fragmentTimer <= 0.0f)
            {
                outOfZone = true;
                Destroy(this.gameObject);
            }
        }

        UpdateDropShadow();
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {

        if (isQuitting || outOfZone) { return; }

        AudioManager.Instance.PlaySoundVaried("Splash");

        if (isFragment) { return; }

        spitUpAttack.ProjectileDestroyed(aimedTile);

        // Destroy aim indicators
        for (int i = 0; i < aimIndicators.Count; i++)
        {
            Destroy(aimIndicators[i]);
        }
        aimIndicators.Clear();
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hurtBox = Instantiate(hurtboxPrefab, transform.position, transform.rotation, null);

        if (rockEaten && !isFragment) { Split(); }

        Destroy(hurtBox, 0.1f);
        Destroy(this.gameObject);
    }

    private void Split()
    {
        for (int i = 0; i < fragmentDirections.Length; i++)
        {
            BossSpitProjectile fragment = Instantiate(this.gameObject, transform.position + fragmentDirections[i] * 10.0f + Vector3.up * 10.0f,
                transform.rotation, null).GetComponent<BossSpitProjectile>();
            fragment.isFragment = true;
        }
    }

    //public void AddAimIndicators(List<GameObject> newIndicators)
    //{
    //    aimIndicators = newIndicators;
    //}

    private void UpdateDropShadow()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, dropShadowMaxRange, dropShadowMask))
        {
            if (hitInfo.distance > dropShadowMaxRange || hitInfo.distance < 0.0f)
            {
                dropShadow.SetActive(false);
                return;
            }

            float newScale = Mathf.Lerp(dropShadowMinScale, dropShadowMaxScale, (dropShadowMaxRange - hitInfo.distance) / dropShadowMaxRange);
            dropShadow.SetActive(true);
            dropShadow.transform.localScale = Vector3.one * newScale;
            dropShadow.transform.position = hitInfo.point + Vector3.up * 0.1f;
        }
        else
        {
            dropShadow.SetActive(false);
        }
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * dropShadowMaxRange);
    }
}
