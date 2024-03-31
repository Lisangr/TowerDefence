using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera camera;
    private Vector3 startPosition;

    private float targetPositionX;
    private float targetPositionY;
    private float targetPositionZ;
    public float speed;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            float positionX = camera.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;
            float positionZ = camera.ScreenToWorldPoint(Input.mousePosition).z - startPosition.z;
            float positionY = camera.ScreenToWorldPoint(Input.mousePosition).y - startPosition.y;

            targetPositionX = Mathf.Clamp(transform.position.x - positionX, 0f, 1f);
            targetPositionZ = Mathf.Clamp(transform.position.z - positionZ, 0f, 1f);
            targetPositionY = Mathf.Clamp(transform.position.y - positionY, 0f, 1f);
        }

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetPositionX, speed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, targetPositionY, speed * Time.deltaTime),
            Mathf.Lerp(transform.position.z, targetPositionZ, speed * Time.deltaTime)
        );
    }
}

