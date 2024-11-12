using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthSystem>() != null)
        {
            print(collision.gameObject.tag);
            collision.gameObject.GetComponent<HealthSystem>().Hit(damage);

        }
    }
}
