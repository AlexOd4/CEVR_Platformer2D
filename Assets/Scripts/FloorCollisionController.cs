using UnityEngine;

public class FloorCollisionController : MonoBehaviour
{
    private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded; } }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("detected" + collision.gameObject.name);
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("fuera" + collision.gameObject.name);
        _isGrounded = false;
    }

    
}
