using UnityEngine;

public class TheSun : MonoBehaviour
{
    private Transform target; // —сылка на объект Stage
    public void Awake()
    {
        target = GameObject.Find("Gate").transform;
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.position, Vector3.up);
        }
    }
}
