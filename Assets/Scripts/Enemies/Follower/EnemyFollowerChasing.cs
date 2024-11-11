using UnityEngine;

public class EnemyFollowerChasing : MonoBehaviour
{
    [SerializeField] EnemyFollowerMovement enemyFollow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCollision"))
        enemyFollow.IsChasing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCollision"))
            enemyFollow.IsChasing = false;
    }
}
