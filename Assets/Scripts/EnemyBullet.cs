using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }


}