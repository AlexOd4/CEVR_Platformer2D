using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private bool _isEndJumpMode;
    private bool _isAttacking;
    public bool IsEndJumpMode { get { return _isEndJumpMode; } set { _isEndJumpMode = value; } }

    [SerializeField] private PlayerInputHandler inputPlayer;
    [SerializeField] private FloorCollisionController ground;
    private Animator anim;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (inputPlayer.Direction.x > 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (inputPlayer.Direction.x < 0 && ground.IsGrounded)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }



        if (inputPlayer.Sprint && inputPlayer.Direction != Vector2.zero && ground.IsGrounded)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else if (!inputPlayer.Sprint && inputPlayer.Direction != Vector2.zero && ground.IsGrounded)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
        }
        else if (inputPlayer.Direction == Vector2.zero && ground.IsGrounded)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }

        if (ground.IsGrounded)
        {
            anim.SetBool("isJumpMode", inputPlayer.JumpMode);
        }

        anim.SetBool("isFalling", !ground.IsGrounded);

        if (!_isEndJumpMode && !ground.IsGrounded) 
        {
            print("estoy");
            _isAttacking = true;
        }
        else if (ground.IsGrounded)
        {
            _isAttacking = false;
        }

        if (_isAttacking && !ground.IsGrounded)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

    }

    public void Delay()
    {
        _isEndJumpMode = true;
    }
}
