using UnityEngine;

public class LevelTriggered : MonoBehaviour
{

    [SerializeField] private int levelInt;

    private void Awake()
    {
        if (GameManager.Instance.level <= levelInt)
            GameManager.Instance.level = levelInt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollision"))
        {
            GameManager.Instance.Save();
        }
    }
}
