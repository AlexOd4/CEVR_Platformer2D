using UnityEditor.UI;
using UnityEngine;

public class EnemyCrawlerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool _moveLeft;
    public bool MoveLeft { get { return _moveLeft; } }


    [Header("Floor Collisioners")]
    [SerializeField] private FloorTriggerController rightWallCollision;
    [SerializeField] private FloorTriggerController leftWallCollision;

    private float currentRotation;

    private void FixedUpdate()
    {
        currentRotation = this.transform.rotation.eulerAngles.z;

        this.transform.Translate(_moveLeft ? -speed * Time.deltaTime : speed * Time.deltaTime, 0, 0, Space.Self);
        
    }

    public void CrawlingDetector()
    {
        print("disparo");
        if (!(leftWallCollision.IsGrounded && rightWallCollision.IsGrounded))
        {
            this.transform.Rotate(new Vector3(0, 0, _moveLeft ? 90 : -90));
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