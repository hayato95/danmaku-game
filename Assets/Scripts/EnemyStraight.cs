using UnityEngine;

public class EnemyStraight : Enemy
{
    protected override void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
