using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private int _extraForce = 0;
    public int ExtraForce { get { return _extraForce; } set { _extraForce = value; } }

    [SerializeField] private PlayerMovementController movePlayer;
    [SerializeField] private PlayerInputHandler inputPlayer;
    [SerializeField] private FloorCollisionController ground;
    private Animator anim;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        flipPlayer();

        anim.SetInteger("XMove", (int)Mathf.Round(movePlayer.Velocity.x));
        anim.SetInteger("YMove", (int)Mathf.Round(movePlayer.Velocity.y));
        anim.SetBool("isJumpMode", inputPlayer.JumpMode);
        anim.SetBool("isRunning", inputPlayer.Sprint);
        anim.SetBool("isGrounded", ground.IsGrounded);

    }

    private void flipPlayer()
    {
        if (inputPlayer.Direction.x > 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (inputPlayer.Direction.x < 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void IsEndJumpModeToTrue()
    {
        if (_extraForce >= 50) _extraForce = 50;
        else _extraForce += 5;
    }
}
