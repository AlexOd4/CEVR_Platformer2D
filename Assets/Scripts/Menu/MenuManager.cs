using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;
    [SerializeField] Animator anim;

    public void SwitchPanel(GameObject switchPanel)
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }

        switchPanel.SetActive(true);

        GameManager.Instance.FindChildByTag(switchPanel.transform, "SelectedButton").gameObject.GetComponent<Button>();
    }

    public void ChangeSceneWithAnimation(GameManager.LevelSelection levelSelected)
    {
        anim.Play("fadeIn");
        GameManager.Instance.currentLevel = levelSelected;
    }


    public void QuitGame()
    {
        print("I hope I see you soon");
        Application.Quit();
    }

}
