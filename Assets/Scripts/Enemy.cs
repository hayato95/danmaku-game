using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] private float fireInterval = 2f;
    [SerializeField] protected int enemyHP = 3;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private BulletPatternManager bulletPatternManager;

    private float fireTimer = 0f;

    void Update()
    {
        Move();
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }

        CheckBoundary();

    }

    protected abstract void Move();


    protected virtual void CheckBoundary()
    {
        if (transform.position.y < -6f) // ‰æ–ÊŠO‚Éo‚½‚ç
        {
            Destroy(gameObject); // Enemy‚ð”j‰ó

        }
    }

    private void Fire()
    {
        bulletPatternManager.FireAimed(bulletSpeed);
    }

    protected virtual void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            enemyHP--;
            Destroy(other.gameObject); // ƒvƒŒƒCƒ„[‚Ì’e‚ð”j‰ó
            if(enemyHP <= 0)
            {
                Destroy(gameObject); // Enemy‚ð”j‰ó
            }
        }
    }
}