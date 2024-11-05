using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private bool _isEndJumpMode;
    private bool _isAttacking;
    public bool IsEndJumpMode { get { return _isEndJumpMode; } set { _isEndJumpMode = value; } }

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
        //Flip player
        if (inputPlayer.Direction.x > 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (inputPlayer.Direction.x < 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (ground.IsGrounded)
        {

            if (inputPlayer.Direction != Vector2.zero)
            {
                anim.SetBool("isRunning", inputPlayer.Sprint);
                anim.SetBool("isWalking", !inputPlayer.Sprint);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", false);
            }

            anim.SetBool("isJumpMode", inputPlayer.JumpMode);
        }
        else
        {

        }

        if (_isAttacking && !ground.IsGrounded)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        anim.SetBool("isFalling", !ground.IsGrounded);

    }

    public void Delay()
    {
        _isEndJumpMode = true;
    }

}
