using UnityEngine;

public class EnemySiderAttackTrigger : MonoBehaviour
{
    [SerializeField] EnemySiderMovement enemyMove;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            //We Hit the player
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);

            //We start the sound of taking damage
            collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().StartSfx(
    collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().audioDamage);

            //We push the player
            collision.transform.parent.transform.parent.GetComponent<Rigidbody2D>().AddForce(
    (collision.transform.parent.transform.parent.position - this.gameObject.transform.position).normalized * enemyMove.PushForce);
        }
    }
}
