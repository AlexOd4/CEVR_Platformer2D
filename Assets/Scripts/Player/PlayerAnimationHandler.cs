using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private int _extraForce = 0;
    public int ExtraForce { get { return _extraForce; } set { _extraForce = value; } }

    [SerializeField] private PlayerMovementController movePlayer;
    [SerializeField] private PlayerInputHandler inputPlayer;
    [SerializeField] private FloorCollisionController ground;
    [SerializeField] private GameObject attackCollision;
    private Animator anim;

    [SerializeField] private GameObject arrow;
    [SerializeField] private SpriteRenderer arrowFill;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        attackCollision.SetActive(!ground.IsGrounded);
    }

    private void FixedUpdate()
    {
        flipPlayer();

        anim.SetInteger("XMove", (int)Mathf.Round(movePlayer.Velocity.x));
        anim.SetInteger("YMove", (int)Mathf.Round(movePlayer.Velocity.y));
        anim.SetBool("isJumpMode", inputPlayer.JumpMode);
        anim.SetBool("isRunning", inputPlayer.Sprint);
        anim.SetBool("isGrounded", ground.IsGrounded);
        ArrowPoint();
    }

    private void ArrowPoint()
    {
        if (inputPlayer.JumpMode)
        {
            arrow.SetActive(true);
            // Calculate the angle of the normalized Vector 2 and pass it to degrees
            float angle = Mathf.Atan2(inputPlayer.LookAt.y, inputPlayer.LookAt.x) * Mathf.Rad2Deg; 
            arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90.0f));

            // We change its height to change the status of extraforce (the image is in DrawMode.Tiled)
            arrowFill.size = new Vector2(arrowFill.size.x, 
                             GameManager.Instance.NormalizeFloat(ExtraForce, 0, 50));
        }
        else
        {
            arrow.SetActive(false);
            arrow.GetComponent<SpriteRenderer>().color = Color.gray;
        }
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
        arrow.GetComponent<SpriteRenderer>().color = Color.white;
        if (_extraForce >= 50) _extraForce = 50;
        else _extraForce += 5;
    }

}
