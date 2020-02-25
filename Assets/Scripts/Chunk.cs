using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class Chunk : MonoBehaviour
{
    public GroundType type;
    public static float raiseTime = 0.5f;
    public static float raiseAmount = 10.0f;
    public static float damage = 10.0f;
    [HideInInspector] public GridTile owner;
    private Rigidbody rigidBody;
    private Vector3 spawnPosition;
    private float amountRaised = 0.0f;
    private bool isRaising = false;
    [HideInInspector] public bool isRaised = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        spawnPosition = transform.position;
    }

    public void StartRaise()
    {
        if (isRaised) { return; }

        transform.DOKill();
        transform.DOMoveY(spawnPosition.y + raiseAmount, raiseTime - amountRaised / raiseTime);

        isRaising = true;
    }

    public void StopRaise()
    {
        if (isRaised) { return; }

        transform.DOKill();
        transform.DOMoveY(spawnPosition.y, amountRaised / raiseTime);

        isRaising = false;
    }

    private void Update()
    {
        RaiseUpdate();
    }

    private void RaiseUpdate()
    {
        if (isRaising)
        {
            amountRaised = Mathf.Clamp(amountRaised + Time.deltaTime/raiseTime, 0.0f, 1.0f);
        }
        else
        {
            amountRaised = Mathf.Clamp(amountRaised - Time.deltaTime / raiseTime, 0.0f, 1.0f);
        }

        if (amountRaised > 0.99f)
        {
            isRaised = true;
        }

        if (amountRaised < 0.01f && !isRaising)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void Hit(Vector3 hitVec)
    {
        if (!isRaised) { return; }

        rigidBody.isKinematic = false;
        rigidBody.drag = 0.0f;

        Debug.Log(hitVec);

        rigidBody.AddForce(hitVec, ForceMode.Impulse);

        owner.RemoveChunk();
    }

    private void OnCollisionEnter(Collision collision)
    {
        FrogBoss boss = collision.gameObject.GetComponent<FrogBoss>();

        if (boss)
        {
            boss.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
