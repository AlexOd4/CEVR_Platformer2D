using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Slider heartSlider;
    private void Update()
    {
        //if (player.GetComponent<HealthSystem>().Life <= 0)
            heartSlider.value = player.GetComponent<HealthSystem>().Life;
        //else
        //    heartSlider.value = player.GetComponent<HealthSystem>().Life + 5;

    }
}
