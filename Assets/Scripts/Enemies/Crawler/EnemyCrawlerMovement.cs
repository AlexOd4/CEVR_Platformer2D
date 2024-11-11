using UnityEditor.UI;
using UnityEngine;

public class EnemyCrawlerMovement : HealthSystem
{
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
        }
    }
    private void FixedUpdate()
    {
        currentRotation = this.transform.rotation.eulerAngles.z;

        this.transform.Translate(_moveLeft ? -speed * Time.deltaTime : speed * Time.deltaTime, 0, 0, Space.Self);    
    }

    public void CrawlingDetector(bool wallCollision)
    {
        print("disparo");
        if (wallCollision)
        {
            this.transform.Rotate(new Vector3(0, 0, _moveLeft ? 90 : -90));
        }
    }
}