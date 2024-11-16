using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneOnAnimation : MonoBehaviour
{
    public void sceneToChange()
    {
        SceneManager.LoadScene("level");
    }
}
