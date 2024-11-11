using UnityEngine;
using UnityEngine.UIElements;

public class EnemySiderMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool _moveLeft;
    public bool MoveLeft { get { return _moveLeft; } set { _moveLeft = value; } }

    private float currentRotation;


    private void FixedUpdate()
    {
        this.transform.Translate(_moveLeft ? -speed * Time.deltaTime : speed * Time.deltaTime, 0, 0);    
    }
}