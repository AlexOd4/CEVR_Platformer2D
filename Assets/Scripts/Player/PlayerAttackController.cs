using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] PlayerMovementController playerMove;
    [SerializeField] private int damage;
    [SerializeField] private GameObject particle;

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

            //Setting the color in red if the damage has been take and the enemy is not dead
            if (collision.gameObject.GetComponentInChildren<SpriteRenderer>() != null)
                collision.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            
            //instance particles
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.identity);
            
            //play the sound of hitting a enemy
            playerMove.StartSfx(playerMove.audioHit);

            //We actually hit the enemy
            collision.gameObject.GetComponent<HealthSystem>().Hit(damage);
            
        }
    }
}
