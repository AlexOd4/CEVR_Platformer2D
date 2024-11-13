using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Animator anim;

    [Header("Level Buttons")]
    [SerializeField] Button[] levelButton;

    private void Awake()
    {
        GameManager.Instance.Load();

        InteractableButton();
    }

    /// <summary>
    /// It looks for the quantity of level achieved and activate the buttons to be interactable 
    /// for each level 
    /// </summary>
    private void InteractableButton()
    {
        print("o");
        for (int i = 0; i <= GameManager.Instance.level; i++)
        {
            print("b");

            if (i < levelButton.Length)
            {
                print("a");
                levelButton[i].interactable = true;
            }
        }
    }

    public void SwitchPanel(GameObject switchPanel)
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }

        switchPanel.SetActive(true);

        GameManager.Instance.FindChildByTag(switchPanel.transform, "SelectedButton").gameObject.GetComponent<Button>().Select();
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
