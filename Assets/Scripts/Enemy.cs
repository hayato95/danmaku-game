using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireInterval = 2f;

    private float fireTimer = 0f;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }

        if (transform.position.y < -6f) // ‰æ–ÊŠO‚Éo‚½‚ç
        {
            Destroy(gameObject); // Enemy‚ð”j‰ó

        }
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}