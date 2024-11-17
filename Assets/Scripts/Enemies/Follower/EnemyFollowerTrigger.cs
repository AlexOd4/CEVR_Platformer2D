using UnityEngine;

public class EnemyFollowerTrigger : MonoBehaviour
{
    private HealthSystem enemyHealth;
    private EnemyFollowerMovement enemyMove;

    private void Awake()
    {
        enemyHealth = transform.parent.GetComponent<HealthSystem>();
        enemyMove = transform.parent.GetComponent<EnemyFollowerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);
            enemyHealth.Kill();
            
            collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().StartSfx(
       collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().audioDamage);

            collision.transform.parent.transform.parent.GetComponent<Rigidbody2D>().AddForce(
                (collision.transform.parent.transform.parent.position - this.gameObject.transform.position).normalized * enemyMove.PushForce);
        }
    }
}

