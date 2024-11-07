using UnityEngine;

public class EnemyFloorTrigger : MonoBehaviour
{
    private bool _isTriggered;

    [SerializeField] private EnemyCrawlerMovement enemyCrawler;

    /// <summary>
    /// Returns for an instance true of a trigger of a collision trigger
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {

        enemyCrawler.CrawlingDetector();

    }
}
