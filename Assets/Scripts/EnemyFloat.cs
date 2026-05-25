using System.Collections;
using UnityEngine;

public class EnemyFloat : Enemy
{

    [SerializeField] private float stayDuration;
    [SerializeField] private Vector2 entryDirection;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;

    private Vector2 leaveDirection;

    enum MoveState
    {
        Entering,
        Staying,
        Leaving,
    }

    private MoveState currentState = MoveState.Entering;

    private void Start()
    {
        StartCoroutine(EnemyMoveRoutine());
        leaveDirection = entryDirection; 
    }

    protected override void Move()
    {
        if(currentState == MoveState.Entering)
        {
            transform.Translate(entryDirection * moveSpeed * Time.deltaTime);
        }

        else if (currentState == MoveState.Staying)
        {
            float x = Mathf.Sin(Time.time * frequency) * amplitude;
            float y = Mathf.Cos(Time.time * frequency) * amplitude;
            transform.Translate(new Vector2(x, y) * Time.deltaTime);
        }
        else if (currentState == MoveState.Leaving)
        {
            transform.Translate(leaveDirection * moveSpeed * Time.deltaTime);
        }
    }


    private IEnumerator EnemyMoveRoutine()
    {
        // “üêŠ®—¹‚Ü‚Å‘Ò‚Â
        yield return new WaitUntil(() => transform.position.x >= 0f);

        currentState = MoveState.Staying;

        yield return new WaitForSeconds(stayDuration);

        currentState = MoveState.Leaving;
    }
}
