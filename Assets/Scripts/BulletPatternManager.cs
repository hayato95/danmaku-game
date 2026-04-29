using System.Collections;
using UnityEngine;

public class BulletPatternManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int spreadCount = 3;
    [SerializeField] private float spreadAngle = 30f;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = FindFirstObjectByType<PlayerController>().transform;

    }


    
    public void FireAimed(float bulletSpeed)
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;


    }



    public void FireSpread(float bulletSpeed)
    {
        float startAngle = -spreadAngle / 2f;
        float angleStep = spreadAngle / (spreadCount - 1);

        for (int i = 0; i < spreadCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
        }
    }

    public void FireStraight(float bulletSpeed)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * bulletSpeed;
    }
}