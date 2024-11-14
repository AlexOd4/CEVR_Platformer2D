using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthSystem>() != null)
        {
            if (collision.gameObject.CompareTag("EnemyCrawler"))
                GameManager.Instance.currentScore += 520;
            else if (collision.gameObject.CompareTag("EnemySider"))
                GameManager.Instance.currentScore += 750;
            else if (collision.gameObject.CompareTag("EnemyFollower"))
                GameManager.Instance.currentScore += 1030;
            else if (collision.gameObject.CompareTag("EnemyJumper"))
                GameManager.Instance.currentScore += 1500;
            else
                print(collision.gameObject.tag);
                GameManager.Instance.currentScore += 200;


            collision.gameObject.GetComponent<HealthSystem>().Hit(damage);
        }
    }
}
