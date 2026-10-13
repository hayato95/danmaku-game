using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    private Rigidbody2D bulletRigidBody;
    private float topBound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody2D>();

        //上方向に弾を発射
        bulletRigidBody.linearVelocity = Vector2.up * bulletSpeed;

        topBound =Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
}
