using UnityEngine;

public class FloorTriggerController : MonoBehaviour
{
    private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("detected" + collision.gameObject.name);
        _isGrounded = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("fuera" + collision.gameObject.name);
        _isGrounded = false;
    }
}
