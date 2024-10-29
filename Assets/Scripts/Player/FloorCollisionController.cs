using UnityEngine;

public class FloorCollisionController : MonoBehaviour
{
    private bool _isGrounded;
    public bool Touch { get { return _isGrounded; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }
}
