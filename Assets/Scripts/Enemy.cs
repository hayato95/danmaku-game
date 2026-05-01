using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float fireInterval = 2f;
    [SerializeField] protected int enemyHP = 3;
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected BulletPatternManager bulletPatternManager;

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
        if (Mathf.Abs(transform.position.x) > 3f || Mathf.Abs(transform.position.y) > 6f) // ‰æ–ÊŠO‚Éo‚½‚ç
        {
            OnDied();
        }
    }

    protected virtual void Fire()
    {
        bulletPatternManager.FireAimed(bulletSpeed);
    }

    protected virtual void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            enemyHP--;
            Destroy(other.gameObject); // ƒvƒŒƒCƒ„[‚Ì’e‚ğ”j‰ó
            if(enemyHP <= 0)
            {
                OnDied();
            }
        }
    }

    protected virtual void OnDied()
    {
        WaveManager.Instance.OnEnemyDefeated(); // WaveManager‚É“G‚ª“|‚³‚ê‚½‚±‚Æ‚ğ’Ê’m
        Destroy(gameObject);
    }

}