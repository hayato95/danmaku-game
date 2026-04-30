using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private float moveRangeX = 2.5f;
    [SerializeField] private int allDirectionsBulletCount = 12;
    private int phaseNumber = 1;

    private void Start()
    {
      enemyHP = MaxHP;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        PhaseManager();

    }

    protected void PhaseManager()
    {
        if ((enemyHP * 100) / MaxHP <= 66 && phaseNumber == 1)
        {
            phaseNumber = 2;
        }

        if ((enemyHP * 100) / MaxHP <= 33 && phaseNumber == 2)
        {
            phaseNumber = 3;
        }

    }

    protected override void Move() 
    {
        float currentX = Mathf.Sin(Time.time) * moveRangeX * moveSpeed;
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }

    protected override void CheckBoundary()
    {
        //ˆ—
    }


    protected override void Fire()
    {
        if(phaseNumber == 1)
        {
            bulletPatternManager.FireAllDirections(bulletSpeed, allDirectionsBulletCount);
        }
    }

}
