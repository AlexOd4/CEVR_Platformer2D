using UnityEditor.UI;
using UnityEngine;

public class EnemyCrawlerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool _moveLeft;
    public bool MoveLeft { get { return _moveLeft; } }


    [Header("Floor Collisioners")]
    [SerializeField] private FloorCollisionController floorCollision;
    [SerializeField] private FloorCollisionController rightWallCollision;
    [SerializeField] private FloorCollisionController leftWallCollision;

    private Rigidbody2D rb2D;
    private float currentRotation;
    private bool ignoreCollision;
    private void Awake()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        currentRotation = this.transform.rotation.eulerAngles.z;
        CrawlingDetector();
        rb2D.linearVelocityX = ((_moveLeft ? -1 : 1) * speed * Time.deltaTime);
        
    }

    private void CrawlingDetector()
    {
        if (!floorCollision.IsGrounded)
        {
            print("b");
            if (!(leftWallCollision.IsGrounded && rightWallCollision.IsGrounded))
            {
                //this.transform.Rotate(new Vector3(0, 0, _moveLeft ? currentRotation + 90 : currentRotation - 90));
                rb2D.MoveRotation(_moveLeft ? currentRotation + 90 : currentRotation - 90);
            }
            else if (!leftWallCollision.IsGrounded && rightWallCollision.IsGrounded)
            {
                //this.transform.Rotate(new Vector3(0, 0, currentRotation + 90));
                rb2D.MoveRotation(currentRotation + 90);

            }
            else if (leftWallCollision.IsGrounded && !rightWallCollision.IsGrounded)
            {
                //this.transform.Rotate(new Vector3(0, 0, currentRotation - 90));
                rb2D.MoveRotation(currentRotation - 90);
            }
        }
        else
        {
            print("a");
        
        }
    }
}