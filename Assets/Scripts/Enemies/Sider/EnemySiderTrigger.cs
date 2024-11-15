using UnityEngine;

public class EnemySiderTrigger : MonoBehaviour
{
    [SerializeField] private EnemySiderMovement siderMove;
    [SerializeField] private SpriteRenderer siderSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        siderMove.MoveLeft = !siderMove.MoveLeft;
        siderSprite.flipX = !siderSprite.flipX;

    }
}
