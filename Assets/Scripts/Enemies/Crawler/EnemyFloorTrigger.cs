using UnityEngine;

public class EnemyFloorTrigger : MonoBehaviour
{

    [SerializeField] private EnemyCrawlerMovement enemyCrawler;
    [SerializeField] private bool isSide;

    /// <summary>
    /// Returns for an instance true of a trigger of a collision trigger ENTER
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSide)
        enemyCrawler.CrawlingDetector(isSide);

    }

    /// <summary>
    /// Returns for an instance true of a trigger of a collision trigger EXIT
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isSide)
        enemyCrawler.CrawlingDetector(isSide);

    }
}
