using UnityEngine;

public class EnemySiderAttackTrigger : MonoBehaviour
{
    [SerializeField] EnemySiderMovement enemyMove;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(enemyMove.Damage);
        }
    }
}
