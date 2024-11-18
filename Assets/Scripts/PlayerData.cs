using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int level;
    public int globalScore;
    public int levelScore01;
    public int levelScore02;
    public int levelScore03;

    /// <summary>
    /// Data to be saved form the gameManager
    /// </summary>
    /// <param name="gameManager"></param>
    public PlayerData (GameManager gameManager)
    {

        level = gameManager.level;
        globalScore = gameManager.globalScore;
        levelScore01 = gameManager.levelScore01;
        levelScore02 = gameManager.levelScore02;
        levelScore03 = gameManager.levelScore03;
    }

}
