using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneOnAnimation : MonoBehaviour
{
    public void sceneToChange()
    {
        if (GameManager.Instance.GetSceneToCharge() != "none")
        {
            SceneManager.LoadScene(GameManager.Instance.GetSceneToCharge());
        }
        else
        {
            print("ERROR");
        }
    }
}
