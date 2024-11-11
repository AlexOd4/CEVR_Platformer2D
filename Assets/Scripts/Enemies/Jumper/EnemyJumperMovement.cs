using UnityEngine;

public class EnemyJumperMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpRate = 1.0f;
    [SerializeField] private int _damage = 5;
    public int Damage { get { return _damage; } }
    
    private Transform playerTransform;
    private Rigidbody2D rb2D;
    private bool invoker = true;


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (invoker && this.transform.position.y < playerTransform.position.y)
        {
            Invoke(nameof(Jump), jumpRate);
            invoker = false;
        }
    }

    private void Jump()
    {
        invoker = true;
        rb2D.AddForce( jumpForce * (playerTransform.position - this.transform.position).normalized,
            ForceMode2D.Impulse);
    }
}
