using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {

        if (Mathf.Abs(transform.position.x) > 3f || Mathf.Abs(transform.position.y) > 6f)
        {
            Destroy(gameObject);
        }
    }


}