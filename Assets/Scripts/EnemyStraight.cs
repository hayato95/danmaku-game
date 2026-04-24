using UnityEngine;

public class EnemyStraight : Enemy
{
    public override void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }
}
