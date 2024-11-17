using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyFollowerMovement : MonoBehaviour
{
    [Header("Set Up Parameters")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform[] patrolPoints;
    private Transform playerTransform;
    private int patrolIndex;
    private Vector2 patrolPointDistance;

    [Header("Movement Parameters")]
    private float baseSpeed;
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float chaseSpeed = 75.0f;
    [SerializeField] private float seekUpdate = 0.75f;

    [Header("Damage Parameter")]
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _pushForce = 1000;

    public int PushForce { get { return _pushForce; } }
    public int Damage { get { return _damage; } }

    private Vector2 enemyDirection;
    private bool invoker = true;

    private bool _isChasing;
    public bool IsChasing { get { return _isChasing; } set { _isChasing = value; } }

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patrolPointDistance = patrolPoints[0].position;
        baseSpeed = speed;
    }

    private void FixedUpdate()
    {

        if (_isChasing) //If is Chasing the player it will take as enemyDirection player 
        {
            //It has a little delay to follow you
            if (invoker)
            {
                invoker = false;
                Invoke(nameof(SetPlayerLastPosition), seekUpdate);
            }
            speed = chaseSpeed;
        }
        else //If is NOT Chasing it will be in patrol mode
        {
            speed = baseSpeed;
            EnemyPatrol();
            enemyDirection = (patrolPoints[patrolIndex].position - this.transform.position).normalized;
        }

        
        GetComponentInChildren<SpriteRenderer>().flipX = (rb2D.linearVelocityX > 0);

        //We applyes the movement and direction of the Enemy
        rb2D.linearVelocity =  enemyDirection * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            Destroy(this.gameObject);
        }
    }



    /// <summary>
    /// It looks for the nearest point and patrol to it straight line, also sets new patrol point when is reached
    /// </summary>
    private void EnemyPatrol()
    {
        //Buscamos el punto más cercano al que volver
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

        if (patrolIndex >= patrolPoints.Length)
            patrolIndex = 0;
    }

    /// <summary>
    /// Update last position of the player
    /// </summary>
    private void SetPlayerLastPosition()
    {
        invoker = true;
        enemyDirection = (playerTransform.position - this.transform.position).normalized;

    }
}
