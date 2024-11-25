using UnityEngine;

public class EnemyJumperMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpRate = 1.0f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _pushForce = 1000;
    [SerializeField] private Vector2 offsetPlayerPosition = new Vector2(0.0f, 15.0f);

    public int PushForce { get { return _pushForce; } }
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

    
    /// <summary>
    /// Se utiliza para que el enemigo salte
    /// </summary>
    private void Jump()
    {
        invoker = true;
        rb2D.AddForce( jumpForce * ((playerTransform.position + new Vector3(offsetPlayerPosition.x, offsetPlayerPosition.y, 0.0f)) - this.transform.position).normalized,
            ForceMode2D.Impulse);
    }
}
