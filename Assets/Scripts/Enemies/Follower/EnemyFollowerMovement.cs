using UnityEngine;

public class EnemyFollowerMovement : MonoBehaviour
{
    [Header("Set Up Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform[] patrolPoints;
    private int patrolIndex;
    private Vector2 patrolPointDistance;

    [Header("Movement Parameters")]
    [SerializeField] private int speed;

    private Vector2 playerLastPosition;
    private Vector2 enemyDirection;
    private bool invoker = true;

    private bool _isChasing;
    public bool IsChasing { get { return _isChasing; } set { _isChasing = value; } }

    private void Awake()
    {
        patrolPointDistance = patrolPoints[0].position;
    }

    private void FixedUpdate()
    {
        if (invoker)
        {
            invoker = false;
            Invoke(nameof(SetPlayerLastPosition), 0.5f);
        }

        if (_isChasing)
        {
            enemyDirection = (playerTransform.position - this.transform.position).normalized;

        }
        else
        {
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (Vector2.Distance(patrolPoints[i].position, this.transform.position) < Vector2.Distance(patrolPointDistance, this.transform.position))
                {
                    patrolPointDistance = patrolPoints[i].position;
                    patrolIndex = i;
                }
            }

            if (Vector2.Distance(patrolPoints[patrolIndex].position, this.transform.position) <= 1.0f)
            {
                patrolIndex++;
            }

            //TODO Ponerlo en cero

            enemyDirection = (patrolPoints[patrolIndex].position - this.transform.position).normalized;

        }
        rb2D.linearVelocity =  enemyDirection * speed * Time.deltaTime;
    }

    private void SetPlayerLastPosition()
    {
        playerLastPosition = playerTransform.position;
        invoker = true;
    }
}
