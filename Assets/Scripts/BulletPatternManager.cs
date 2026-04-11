using System.Collections;
using UnityEngine;

public class BulletPatternManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int spreadCount = 3;
    [SerializeField] private float spreadAngle = 30f;

    /// <summary>
    /// スプレッド弾を発射する。spreadCount発をspreadAngleの範囲で均等に散らす
    /// </summary>
    public void FireSpread()
    {
        float startAngle = -spreadAngle / 2f;
        float angleStep = spreadAngle / (spreadCount - 1);

        for (int i = 0; i < spreadCount; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f;
        }
    }

    public void FireStraight()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * 5f;
    }
}