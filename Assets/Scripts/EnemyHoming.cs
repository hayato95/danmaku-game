using UnityEngine;

public class EnemyHoming : Enemy
{

    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = FindFirstObjectByType<PlayerController>().transform;
    }

    protected override void Move()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

}
