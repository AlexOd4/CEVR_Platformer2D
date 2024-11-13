using System.Runtime.CompilerServices;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private float parallaxVelocity;

    private Transform cameraTransform;
    private Vector3 previousCameraPoint;
    private float spriteWidth, startPosition;
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPoint = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = this.transform.position.x;
    }

    private void LateUpdate()
    {
        float deltaX = (previousCameraPoint.x - cameraTransform.position.x) * parallaxVelocity;

        //moveAmount is the oposite transform of deltaX
        float moveAmount = cameraTransform.position.x * (1 - parallaxVelocity);
        
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPoint = cameraTransform.position;

    }
}
