﻿using System.Collections;
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
    private Rigidbody rigidBody;
    private Vector3 spawnPosition;
    [HideInInspector] public bool isRaised = false;
    [HideInInspector] public GridTile owningTile;

    private bool attemptingToStop = false;
    private int health = 2;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0) { Death(); }
        }
    }

    private void FixedUpdate()
    {
        //if (attemptingToStop)
        //{
        //    if (rigidBody.velocity == Vector3.zero)
        //    {
        //        attemptingToStop = false;
        //        rigidBody.isKinematic = true;
        //        Debug.Log("Stopped");
        //    }
        //}
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        spawnPosition = transform.position;

        FindObjectOfType<PlayerController>().AddChunk(this); // ew
        AudioManager.Instance.PlaySound("RockCall");
    }

    public void RaiseChunk()
    {
        StartCoroutine(Raise());
    }

    public void Damage(int amount)
    {
        Health -= amount;
        Debug.Log("Damaged");
    }

    private IEnumerator Raise()
    {
        transform.DOKill();
        transform.DOMoveY(spawnPosition.y + raiseAmount, raiseTime).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(raiseTime);

        isRaised = true;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        transform.DOKill();
        if (owningTile) { owningTile.RemoveChunk(); }
        FindObjectOfType<PlayerController>().RemoveChunk(this); // ew
        AudioManager.Instance.PlaySound("RockDestroy");
    }

    public void Hit(Vector3 hitVec)
    {
        if (!isRaised) { return; }

        
        if (IsAgainstWall(hitVec))
        {
            Damage(1);
            return;
        }

        Detach();

        rigidBody.isKinematic = false;
        rigidBody.drag = 0.0f;

        rigidBody.AddForce(hitVec, ForceMode.Impulse);

        AudioManager.Instance.PlaySound("RockHit");
    }

    public void Detach()
    {
        Debug.Log("Detach");
        rigidBody.isKinematic = false;
        rigidBody.drag = 0.0f;
        if (owningTile)
        {
            owningTile.RemoveChunk();
            owningTile = null;
        }
    }

    private bool IsAgainstWall(Vector3 hitVec, float distance = 5.5f)
    {
        Vector3 checkPosition = transform.position;
        checkPosition.y -= 4.5f; // Almost bottom of chunk

        // Raycast in the direction of hit vec for half a chunks length
        if (Physics.Raycast(checkPosition, hitVec, distance))
        {
            // Hit something, thus a wall
            return true;
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Ground" && collision.collider.tag != "Player")
        {
            if (IsAgainstWall(rigidBody.velocity.normalized, 9.5f))
            {
                //attemptingToStop = true;
                rigidBody.velocity = Vector3.zero;
                rigidBody.isKinematic = true;
                Debug.Log("Stopped");
            }
        }
    }
}
