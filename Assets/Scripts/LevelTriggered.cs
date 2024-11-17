using UnityEngine;
using UnityEngine.InputSystem;

public class LevelTriggered : MonoBehaviour
{

    [SerializeField] private int levelInt;
    [SerializeField] private bool isFinalLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!isFinalLevel)
        {
            if (collision.gameObject.CompareTag("PlayerCollision") && GameManager.Instance.level <= levelInt)
            {
                GameManager.Instance.level = levelInt;
                GameManager.Instance.Save();
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("PlayerCollision"))
            {
                collision.transform.parent.transform.parent.GetComponent<PlayerInputHandler>().enabled = false;
                GameObject.FindGameObjectWithTag("EndPanel").gameObject.SetActive(true);
            }
        }
        

    }
}
