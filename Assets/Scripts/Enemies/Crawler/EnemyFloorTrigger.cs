using UnityEngine;

public class EnemyFloorTrigger : MonoBehaviour
{

    [SerializeField] private EnemyCrawlerMovement enemyCrawler;
    [SerializeField] private bool isSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSide)
        enemyCrawler.CrawlingDetector();

    }

    /// <summary>
    /// Returns for an instance true of a trigger of a collision trigger
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isSide)
        enemyCrawler.CrawlingDetector();

    }
}
