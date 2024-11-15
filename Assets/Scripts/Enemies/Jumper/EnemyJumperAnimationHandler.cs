using UnityEngine;

public class EnemyJumperAnimationHandler : MonoBehaviour
{
    [SerializeField] private FloorTriggerController floor;
    private SpriteRenderer jumperSprite;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        jumperSprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (floor.IsGrounded && this.gameObject.GetComponent<Rigidbody2D>().linearVelocity == Vector2.zero)
        {
            anim.Play("EnemyJumper_idle");
        }
        else if (floor.IsGrounded && this.gameObject.GetComponent<Rigidbody2D>().linearVelocity != Vector2.zero)
        {
            anim.Play("EnemyJumper_Crawl");
        }
        else if (!floor.IsGrounded)
        {
            anim.Play("EnemyJumper_jump");
        }

        if (this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x > 0)
            jumperSprite.flipX = false;
        else if (this.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x < 0) 
            jumperSprite.flipX = true;

    }
}
