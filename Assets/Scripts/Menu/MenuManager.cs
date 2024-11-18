using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Animator anim;

    [Header("Level Buttons")]
    [SerializeField] Button[] levelButton;
    [SerializeField] TMP_Text[] levelScoreText;
    [SerializeField] TMP_Text globalScoreText;
    private void Awake()
    {
        GameManager.Instance.Load();

        InteractableButton();


        levelScoreText[0].text = "Score: "  + GameManager.Instance.levelScore01.ToString("D6");
        levelScoreText[1].text = "Score: " + GameManager.Instance.levelScore02.ToString("D6");
        levelScoreText[2].text = "Score: " + GameManager.Instance.levelScore03.ToString("D6");

        globalScoreText.text = "GLOBAL SCORE: " + GameManager.Instance.globalScore.ToString("D6");

    }

    /// <summary>
    /// It looks for the quantity of level achieved and activate the buttons to be interactable 
    /// for each level 
    /// </summary>
    private void InteractableButton()
    {
        for (int i = 0; i <= GameManager.Instance.level; i++)
        {
            if (i < levelButton.Length)
            {
                levelButton[i].interactable = true;
            }
        }
    }


    /// <summary>
    /// Switches the panel given
    /// </summary>
    /// <param name="switchPanel">Panel to be activated</param>
    public void SwitchPanel(GameObject switchPanel)
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }

        switchPanel.SetActive(true);

        //TODO GameManager.Instance.FindChildByTag(switchPanel.transform, "SelectedButton").gameObject.GetComponent<Button>().Select();
    }


    /// <summary>
    /// It Changes the scene at the end of the animation
    /// </summary>
    /// <param name="level"></param>
    public void ChangeSceneWithAnimation(int level)
    {
        GameManager.Instance.level = level;
        GameManager.Instance.Save();
        anim.Play("ChangeScene_FadeIn");
    }


    /// <summary>
    /// Close the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

}
