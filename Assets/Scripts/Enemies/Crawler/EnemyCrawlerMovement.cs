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

    private float currentRotation;
    private bool ignoreCollision;
    private void Awake()
    {
        currentRotation = this.transform.rotation.eulerAngles.z;
    }
    private void FixedUpdate()
    {
        CrawlingDetector();
        this.transform.Translate((_moveLeft ? Vector2.left : Vector2.right) * speed * Time.deltaTime);

    }



    //private void CrawlingDetector()
    //{
    //    if (!floorCollision.IsGrounded)
    //    {
    //        if (!(leftWallCollision.IsGrounded && rightWallCollision.IsGrounded))
    //        {
    //            this.transform.Rotate(new Vector3(0, 0, _moveLeft ? currentRotation + 90 : currentRotation - 90));

    //        }
    //        else if (!leftWallCollision.IsGrounded && rightWallCollision.IsGrounded)
    //        {
    //            this.transform.Rotate(new Vector3(0, 0, currentRotation + 90));

    //        }
    //        else if (leftWallCollision.IsGrounded && !rightWallCollision.IsGrounded)
    //        {
    //            this.transform.Rotate(new Vector3(0, 0, currentRotation - 90));
    //        }
    //    }
    //}

    private void CrawlingDetector()
    {
        if (!floorCollision.IsGrounded)
        {
            if (!(leftWallCollision.IsGrounded && rightWallCollision.IsGrounded))
            {
                this.transform.Rotate(new Vector3(0, 0, _moveLeft ? currentRotation + 90 : currentRotation - 90));

            }
            else if (!leftWallCollision.IsGrounded && rightWallCollision.IsGrounded)
            {
                this.transform.Rotate(new Vector3(0, 0, currentRotation + 90));

            }
            else if (leftWallCollision.IsGrounded && !rightWallCollision.IsGrounded)
            {
                this.transform.Rotate(new Vector3(0, 0, currentRotation - 90));
            }
        }
    }

}
