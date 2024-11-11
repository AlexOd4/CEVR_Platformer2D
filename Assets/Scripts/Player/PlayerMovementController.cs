using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Set Up parameters")]
    [SerializeField] private FloorCollisionController ground;
    [SerializeField] private PlayerAnimationHandler animHandler;
    private PlayerInputHandler inputPlayer;
    
    private Rigidbody2D playerRb;
    public Vector2 Velocity { get { return playerRb.linearVelocity; } }

    [Header("Movement")]
    [SerializeField] private float walkVelocity = 5;
    [SerializeField] private float runVelocity = 10;
    [SerializeField] private float impulseHeight = 5;


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
        //Comprovamos si esta o no en JumpMode
        if (!inputPlayer.JumpMode && ground.IsGrounded)
        {
            if (justReleasedJumpMode && animHandler.ExtraForce > 0)
            {
                justReleasedJumpMode = false;
                ImpulsePlayer(impulseHeight + animHandler.ExtraForce);
                animHandler.ExtraForce = 0;
            }
            else
            {
                if (inputPlayer.Sprint) MovePlayer(runVelocity); else MovePlayer(walkVelocity);
                animHandler.ExtraForce = 0;
            }

        }
        else if (inputPlayer.JumpMode && ground.IsGrounded && animHandler.ExtraForce == 0)
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
