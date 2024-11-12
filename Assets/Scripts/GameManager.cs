using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();
                if (_instance == null) 
                { 
                    GameObject singletonObject = new GameObject("GameManager"); 
                    _instance = singletonObject.AddComponent<GameManager>(); 
                    DontDestroyOnLoad(singletonObject); 
                }
            }
            return _instance;
        }
    }
    private GameManager() { }

    //LevelSelector
    public enum LevelSelection
    {
        None,
        Level01,
        Level02,
        Level03,
    }

    public LevelSelection currentLevel;

    public string GetSceneToCharge()
    {
        switch (currentLevel)
        {
            case LevelSelection.Level01:
                return "level";
            case LevelSelection.Level02:
                return "level";
            case LevelSelection.Level03:
                return "level";
        }
        return "none";
    }

    /// <summary>
    /// Looks for a child in the object with an specific tag
    /// </summary>
    /// <param name="parent"> The parent of the object to be finded</param>
    /// <param name="tag"> The tag to be specified</param>
    /// <returns></returns>
    public Transform FindChildByTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child;
            }
        }
        return null;
    }

}
