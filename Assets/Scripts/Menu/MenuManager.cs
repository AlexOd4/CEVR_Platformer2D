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
        for (int i = 0; i <= GameManager.Instance.level; i++)
        {
            if (i < levelButton.Length)
            {
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

    public void ChangeSceneWithAnimation(int level)
    {
        GameManager.Instance.level = level;
        print("antesDeCargar: " + GameManager.Instance.level);
        GameManager.Instance.Save();
        anim.Play("ChangeScene_FadeIn");
    }


    public void QuitGame()
    {
        print("I hope I see you soon");
        Application.Quit();
    }

}
