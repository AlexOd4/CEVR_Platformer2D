using NUnit.Framework;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SET UP GAMEMANAGER
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

    #endregion


    #region Level Selector

    public int level = 0;

    #endregion

    public int globalScore = 0;
    public int currentScore = 0;

    public int levelScore01 = 0;
    public int levelScore02 = 0;
    public int levelScore03 = 0;

    /// <summary>
    /// Guarda los datos usando saveSystem
    /// </summary>
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    /// <summary>
    /// Carga los datos guardados
    /// </summary>
    public void Load()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        if (data == null)
        {
            Save();
            data = SaveSystem.LoadPlayer();
        }

        level = data.level;
        globalScore = data.globalScore;
        levelScore01 = data.levelScore01;
        levelScore02 = data.levelScore02;
        levelScore03 = data.levelScore03;
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

    /// <summary>
    /// Normalize a range of numers between its minimum "min" and maximum "max"
    /// </summary>
    /// <param name="value"> Value to be normalized </param>
    /// <param name="min"> min value of the range </param>
    /// <param name="max"> max value of the range </param>
    /// <returns></returns>
    public float NormalizeFloat(float value, float min, float max)
    {
        return (value - min) / (max - min);
    }



}
