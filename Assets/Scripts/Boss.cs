using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private float moveRangeX = 2.5f;
    [SerializeField] private int allDirectionsBulletCount = 12;
    [SerializeField]private int phaseNumber = 1;
    private bool isReady = false;
    private bool waitForBoss = false;

    private void Start()
    {
      enemyHP = MaxHP;
      bulletSpeed = 1f;
      fireInterval = 0.2f;
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
            bulletSpeed = 5f;
            fireInterval = 0.02f;
        }

        if ((enemyHP * 100) / MaxHP <= 33 && phaseNumber == 2)
        {
            phaseNumber = 3;
        }

    }

    protected override void Move() 
    {
        if(isReady == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, 0);
            if(transform.position.y <= 4f)
            {
                isReady = true;
                transform.position = new Vector3(transform.position.x, 4f, 0);
                waitForBoss = true;
                StartCoroutine(BossEntrance());
            }
        }

        else
        {
            if(waitForBoss) return;
            float currentX = Mathf.Sin(Time.time) * moveRangeX * moveSpeed;
            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        }
        
    }

    protected override void CheckBoundary()
    {
        //ˆ—
    }


    protected override void Fire()
    {
        if (isReady == false) return;
        if(waitForBoss) return;

        if (phaseNumber == 1)
        {
            bulletPatternManager.FireAllDirections(bulletSpeed, allDirectionsBulletCount);
        }

        if(phaseNumber == 2)
        {
            
            bulletPatternManager.FireSpiral(bulletSpeed, 11f);
        }
    }

    private IEnumerator BossEntrance()
    {
        yield return new WaitForSeconds(2f);
        waitForBoss = false;
    }
}
