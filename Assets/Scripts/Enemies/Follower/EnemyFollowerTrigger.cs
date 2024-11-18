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
            //We Hit the player
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);
            
            //We Kill the enemy
            enemyHealth.Kill();
            
            //playing the audio of taking damage
            collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().StartSfx(
       collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().audioDamage);

            // We push the player
            collision.transform.parent.transform.parent.GetComponent<Rigidbody2D>().AddForce(
                (collision.transform.parent.transform.parent.position - this.gameObject.transform.position).normalized * enemyMove.PushForce);
        }
    }
}

