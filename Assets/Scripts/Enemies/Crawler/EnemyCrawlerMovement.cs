using UnityEditor.UI;
using UnityEngine;

public class EnemyCrawlerMovement : MonoBehaviour
{
    [Header("Enemy Properties")]
    [SerializeField] private int damage = 5;
    [SerializeField] private int pushForce = 50;

    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool _moveLeft;
    [SerializeField] private BoxCollider2D wallCollisionBox;
    public bool MoveLeft { get { return _moveLeft; } }

    private float currentRotation;

    private void Awake()
    {
        if (_moveLeft)
        {
            wallCollisionBox.offset = -wallCollisionBox.offset;
            this.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }
    private void FixedUpdate()
    {
        currentRotation = this.transform.rotation.eulerAngles.z;

        this.transform.Translate(_moveLeft ? -speed * Time.deltaTime : speed * Time.deltaTime, 0, 0, Space.Self);    
    }

    public void CrawlingDetector(bool wallCollision)
    {
        if (wallCollision)
            this.transform.Rotate(new Vector3(0, 0, _moveLeft ? -90 : 90));
        else
            this.transform.Rotate(new Vector3(0, 0, _moveLeft ? 90 : -90));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            collision.transform.parent.transform.parent.GetComponent<HealthSystem>().Hit(damage);
            collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().StartSfx(
                collision.transform.parent.transform.parent.GetComponent<PlayerMovementController>().audioDamage);
            collision.transform.parent.transform.parent.GetComponent<Rigidbody2D>().AddForce(
                (collision.transform.parent.transform.parent.position - this.gameObject.transform.position).normalized * pushForce);
        }
    }
}