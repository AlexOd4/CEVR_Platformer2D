using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Slider heartSlider;
    [SerializeField] TMP_Text scoreText;
    private void Update()
    {
        heartSlider.value = player.GetComponent<HealthSystem>().Life;

        scoreText.text = "SCORE: " + GameManager.Instance.currentScore.ToString("D5");

    }
}
