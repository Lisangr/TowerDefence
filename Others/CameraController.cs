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
}