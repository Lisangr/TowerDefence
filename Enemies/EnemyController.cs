using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public List<Transform> locations;

    private int sceneSkipped = 0;
    private Transform patrolRoute;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolRoute = GameObject.Find("PatrolRoute").transform;
        StopCutScene.OnCutSceneSkipped += IncrementSceneSkipped;

        InitializePatrolRoute();
    }

    private void IncrementSceneSkipped()
    {
        sceneSkipped += 1;
    }

    private void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    private void Update()
    {
        if (sceneSkipped > 0)
        {
            if (agent.isOnNavMesh && agent.remainingDistance < 2f && !agent.pathPending)
            {
                MoveToNextPatrolLocation();
            }
        }
        else  
        {
            StartCoroutine(EnemyGoing());
        }       
    }
    private void OnDisable()
    {
        StopCutScene.OnCutSceneSkipped -= IncrementSceneSkipped;
    }
    private IEnumerator EnemyGoing()
    {
        yield return new WaitForSeconds(85f);

        if (agent.isOnNavMesh && agent.remainingDistance < 2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;// Устанавливаем пункт назначения для агента
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            Destroy(this.gameObject);
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gate")
        {
            Destroy(this.gameObject);
        }
    }*/
}
