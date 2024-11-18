using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

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
                GameManager.Instance.Load();
                if (levelInt == 1)
                {
                    if (GameManager.Instance.levelScore01 <= GameManager.Instance.currentScore)
                    GameManager.Instance.levelScore01 = GameManager.Instance.currentScore;

                }
                else if (levelInt == 2)
                {
                    if (GameManager.Instance.levelScore02 <= GameManager.Instance.currentScore)
                        GameManager.Instance.levelScore02 = GameManager.Instance.currentScore;
                }
                else if (levelInt == 3)
                {
                    if (GameManager.Instance.levelScore03 <= GameManager.Instance.currentScore)
                        GameManager.Instance.levelScore03 = GameManager.Instance.currentScore;
                }

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
