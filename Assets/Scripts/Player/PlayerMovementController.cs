using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Set Up parameters")]
    [SerializeField] private FloorCollisionController ground;
    [SerializeField] private PlayerAnimationHandler animHandler;
    private PlayerInputHandler inputPlayer;

    [Header("Audios")]
    [SerializeField] public AudioClip audioJump;
    [SerializeField] public AudioClip audioHeal;
    [SerializeField] public AudioClip audioHit;
    [SerializeField] public AudioClip audioDamage;




    private Rigidbody2D playerRb;
    public Vector2 Velocity { get { return playerRb.linearVelocity; } }

    [Header("Movement")]
    [SerializeField] private float walkVelocity = 5;
    [SerializeField] private float runVelocity = 10;
    [SerializeField] private float impulseHeight = 5;


    private bool justReleasedJumpMode;
    public bool JustReleasedJumpMode { get { return justReleasedJumpMode; } }
    private bool delayJumpMode;

    private AudioSource playerSfx;

    private void Start()
    {
        inputPlayer = this.gameObject.GetComponent<PlayerInputHandler>();
        playerRb = this.gameObject.GetComponent<Rigidbody2D>();
        playerSfx = this.gameObject.GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
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
    
    /// <summary>
    /// It moves the player rigidbody with a given velocity
    /// </summary>
    /// <param name="velocity"></param>
    private void MovePlayer(float velocity)
    {

        if (inputPlayer.Direction != Vector2.zero && ground.IsGrounded)
        playerRb.linearVelocityX = velocity * inputPlayer.Direction.x;
    }

    /// <summary>
    /// Impulses the player to mouse direction with an Impulse given
    /// </summary>
    /// <param name="impulse"></param>
    private void ImpulsePlayer(float impulse)
    {
        //We start the audio of Jumping
        StartSfx(audioJump);
        //We add the force to jump
        playerRb.AddForce(inputPlayer.LookAt * impulse, ForceMode2D.Impulse);

    }
    /// <summary>
    /// It Will play the sfx setted on the parametter
    /// </summary>
    /// <param name="audio"></param>
    public void StartSfx(AudioClip audio)
    {
        playerSfx.clip = audio;
        playerSfx.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealObject") && 
            GetComponent<HealthSystem>().Life < GetComponent<HealthSystem>().MaxLife)
        {
            StartSfx(audioHeal);
            this.gameObject.GetComponent<HealthSystem>().Heal(10);
            Destroy(collision.gameObject);
        }
    }

}
