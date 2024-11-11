using UnityEngine;

public class EnemyJumperTrigger : MonoBehaviour
{
    private EnemyJumperMovement enemyMove;
    private void Awake()
    {
        enemyMove = transform.parent.GetComponent<EnemyJumperMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            print("tePiego");
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);
        }
    }
}
