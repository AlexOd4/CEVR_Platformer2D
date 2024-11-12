using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Animator anim;

    private void Awake()
    {
        //LocalLevelSelection = GameManager.LevelSelection;
    }

    public void SwitchPanel(GameObject switchPanel)
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }

        switchPanel.SetActive(true);

        GameManager.Instance.FindChildByTag(switchPanel.transform, "SelectedButton").gameObject.GetComponent<Button>();
    }

    public void ChangeSceneWithAnimation(String level)
    {
        GameManager.LevelSelection levelSelected = GameManager.LevelSelection.None; 
        if(level == "level01")
        {
            levelSelected = GameManager.LevelSelection.Level01;
        }
        else if (level == "level02")
        {
            levelSelected = GameManager.LevelSelection.Level02;
        }
        else if (level == "level03")
        {
            levelSelected = GameManager.LevelSelection.Level03;
        }

        anim.Play("ChangeScene_FadeIn");
        GameManager.Instance.currentLevel = levelSelected;
    }


    public void QuitGame()
    {
        print("I hope I see you soon");
        Application.Quit();
    }

}
