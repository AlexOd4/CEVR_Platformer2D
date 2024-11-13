using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int level;
    public int globalScore;
    public int[] levelScore;

    public PlayerData (GameManager gameManager)
    {

        level = gameManager.level;
        globalScore = gameManager.globalScore;
        levelScore = gameManager.levelScore;
    }

}
