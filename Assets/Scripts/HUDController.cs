using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Slider heartSlider;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text failScoreText;
    [SerializeField] TMP_Text winScoreText;

    [Header("HUDs")]
    [SerializeField] GameObject deathHud;
    [SerializeField] GameObject playerHud;
    private void Update()
    {
        heartSlider.value = player.GetComponent<HealthSystem>().Life;

        scoreText.text = "SCORE: " + GameManager.Instance.currentScore.ToString("D5");
        failScoreText.text = "Achieved Score : " + GameManager.Instance.currentScore.ToString("D5");
        winScoreText.text = "Achieved Score : " + GameManager.Instance.currentScore.ToString("D5");

        if (!(player.GetComponent<PlayerMovementController>().enabled && player.GetComponent<PlayerInputHandler>().enabled))
        {
            playerHud.SetActive(false);
            deathHud.SetActive(true);
        }

    }

    public void toMain()
    {
        GameManager.Instance.Save();
        SceneManager.LoadScene("MainMenu");
    }

}
