using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossHurler : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileCreationTransform;
    public int damage = 1;
    public float attackCooldown = 2.0f;
    public float projectileSpeed = 1.0f;

    private float attackTimer = 0.0f;

    private void Awake()
    {
        attackTimer = attackCooldown;
    }

    private void Update()
    {
        attackTimer = Mathf.Clamp(attackTimer - Time.deltaTime, 0.0f, attackCooldown);

        if (attackTimer < 0.01f)
        {
            FireProjectile();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Chunk>())
        {
            Destroy(collision.collider.gameObject);
            this.Dead();
        }
    }

    private void FireProjectile()
    {
        AudioManager.Instance.PlaySoundVaried("ToadSpit");

        attackTimer = attackCooldown;
        MossHurlerProjectile projectile = Instantiate(projectilePrefab, projectileCreationTransform.position, projectileCreationTransform.rotation, null).GetComponent<MossHurlerProjectile>();
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileSpeed;
        projectile.damage = this.damage;
    }

    public void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
