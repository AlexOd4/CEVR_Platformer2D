using UnityEngine;

public class LevelManagerController : MonoBehaviour
{
    private GameObject playerObject;
    private void Awake()
    {
        GameManager.Instance.Load();
        playerObject = GameObject.FindGameObjectWithTag("Player");

        print("DP " + GameManager.Instance.level);


        if(GameManager.Instance.level == 0)
        {
            playerObject.transform.position = new Vector3(4.01f, -1.30f, 0);
        }
        else if (GameManager.Instance.level == 1)
        {
            print("te muevo nohenque");
            playerObject.transform.position = new Vector3(4.01f, 115.468f, 0);
        }
        else if (GameManager.Instance.level == 2)
        {
            print("te muevo");
            playerObject.transform.position = new Vector3(4.01f, 313.48f, 0);
        }
    }
}
