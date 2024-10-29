using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Set Up parameters")]
    PlayerInputHandler inputPlayer;
    [SerializeField] private FloorCollisionController ground;
    private Rigidbody2D playerRb;

    [Header("Movement")]
    [SerializeField] private float walkVelocity = 5;
    [SerializeField] private float runVelocity = 10;
    [SerializeField] private float impulseHeight = 5;

    private bool isOnJumpMode;

    private void Start()
    {
        inputPlayer = this.gameObject.GetComponent<PlayerInputHandler>();
        playerRb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (inputPlayer.JumpMode && ground.Touch)
        {
            isOnJumpMode = true;
        }
        else
        {
            isOnJumpMode = false;
        }
    }

    private void FixedUpdate()
    {
        //movemos al jugador a velocidad de andar o de correr dependiendo de si esta o no pulsando boton "Sprint"

            if (inputPlayer.Sprint) MovePlayer(runVelocity); else MovePlayer(walkVelocity);
    }
    
    private void MovePlayer(float velocity)
    {
        playerRb.linearVelocityX = velocity * inputPlayer.Direction.x;
    }

    
}
