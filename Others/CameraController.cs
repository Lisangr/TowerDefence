/*using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPoint;
    public float speed;
    public GestureClick gestureClick;

    private Transform selfTransform;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
        gestureClick.OnClick += (pos) =>
        {
            targetPoint.position = pos;
        };
    }

    void Update()
    {
       selfTransform.position = Vector3.MoveTowards(selfTransform.position, 
                                                    targetPoint.position, 
                                                    speed * Time.deltaTime);
    }
}*/
/*
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPoint;
    public float speed;
    public GestureClick gestureClick;

    private Transform selfTransform;
    private bool isRightClicking = false;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
        gestureClick.OnClick += (pos) =>
        {
            targetPoint.position = new Vector3(pos.x, targetPoint.position.y, pos.z);
        };
    }

    void Update()
    {
        selfTransform.position = Vector3.MoveTowards(selfTransform.position,
                                                    targetPoint.position,
                                                    speed * Time.deltaTime);

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
            selfTransform.RotateAround(targetPoint.position, Vector3.up, mouseX * speed);
        }
    }
}*/
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