using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private int crawlerDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyCrawlerCollision"))
        {
            //TODO collision.gameObject.GetComponent<HealthSystem>().Hit(crawlerDamage);
        }
        
    }
}
