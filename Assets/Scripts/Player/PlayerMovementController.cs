using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Set Up parameters")]
    private PlayerInputHandler inputPlayer;
    [SerializeField] private FloorCollisionController ground;
    [SerializeField] private PlayerAnimationHandler animHandler;
    private Rigidbody2D playerRb;

    [Header("Movement")]
    [SerializeField] private float walkVelocity = 5;
    [SerializeField] private float runVelocity = 10;
    [SerializeField] private float impulseHeight = 5;

    public float Velocity 
    { get 
        { 
            if (ground.IsGrounded)
            {
                if (inputPlayer.Direction != Vector2.zero && inputPlayer.Sprint) return walkVelocity;
                else if (inputPlayer.Direction != Vector2.zero && !inputPlayer.Sprint) return runVelocity;
                else if (inputPlayer.Direction == Vector2.zero) return 0;
            }
            return 99;
        } 
    }

    private bool justReleasedJumpMode;
    public bool JustReleasedJumpMode { get { return justReleasedJumpMode; } }
    private bool delayJumpMode;

    private void Start()
    {
        inputPlayer = this.gameObject.GetComponent<PlayerInputHandler>();
        playerRb = this.gameObject.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        //movemos al jugador a velocidad de andar o de correr dependiendo de si esta o no pulsando boton "Sprint"
        if (!inputPlayer.JumpMode && ground.IsGrounded)
        {
            if (justReleasedJumpMode && animHandler.IsEndJumpMode)
            {
                justReleasedJumpMode = false;
                animHandler.IsEndJumpMode = false;
                ImpulsePlayer(impulseHeight);
            }
            else
            {
                if (inputPlayer.Sprint) MovePlayer(runVelocity); else MovePlayer(walkVelocity);
            }

        }
        else if (inputPlayer.JumpMode && ground.IsGrounded)
        {
            justReleasedJumpMode = true;
            playerRb.linearVelocityX = 0;
        }


    }
    
    private void MovePlayer(float velocity)
    {
        if (inputPlayer.Direction != Vector2.zero && ground.IsGrounded)
        playerRb.linearVelocityX = velocity * inputPlayer.Direction.x;
    }

    private void ImpulsePlayer(float impulse)
    {
        playerRb.AddForce(inputPlayer.LookAt * impulse, ForceMode2D.Impulse);

    }

 
    
}
