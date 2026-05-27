using UnityEngine;

public class EnemyCircleOrbit : Enemy
{
    [SerializeField] private Vector2 orbitCenter;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float orbitSpeed; //角速度
    [SerializeField] private float centerSpeed; //重心の移動速度
    [SerializeField] private float centerDirection; //重心の移動方向(1は右、-1は左)




    protected override void Move()
    {
        orbitCenter.x += centerSpeed * centerDirection * Time.deltaTime;

        float x  =  orbitCenter.x + orbitRadius * Mathf.Cos(orbitSpeed * Time.time);
        float y = orbitCenter.y + orbitRadius * Mathf.Sin(orbitSpeed * Time.time);

        transform.position = new Vector2(x, y);
    }
}
