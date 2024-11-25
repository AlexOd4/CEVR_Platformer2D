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
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);
            collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().StartSfx(
                collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().audioDamage);
            collision.transform.parent.transform.parent.GetComponent<Rigidbody2D>().AddForce(
                (collision.transform.parent.transform.parent.position - this.gameObject.transform.position).normalized * enemyMove.PushForce);
        }
    }
}
