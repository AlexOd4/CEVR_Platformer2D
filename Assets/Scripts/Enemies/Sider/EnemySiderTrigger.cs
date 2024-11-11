using UnityEngine;

public class EnemySiderTrigger : MonoBehaviour
{
    [SerializeField] private EnemySiderMovement siderMove;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        siderMove.MoveLeft = !siderMove.MoveLeft;
    }
}
