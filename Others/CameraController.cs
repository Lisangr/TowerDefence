using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public Terrain terrain;
    public Transform targetPoint;

    private Transform selfTransform;
    private bool isMoving = false;
    private bool isRightClicking = false;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                isMoving = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y = selfTransform.position.y; // Keep the same Y position
                selfTransform.position = Vector3.MoveTowards(selfTransform.position, targetPosition, speed * Time.deltaTime);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            isRightClicking = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightClicking = false;
        }

        if (isRightClicking)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y"); 
            selfTransform.RotateAround(targetPoint.position, Vector3.up, mouseX * speed);
            selfTransform.RotateAround(targetPoint.position, selfTransform.right, -mouseY * speed); 
        }
    }
}