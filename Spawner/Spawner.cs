using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(80f);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            spawnedEnemies.Add(newEnemy);
        }
    }
    private void OnDestroy()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
    }
}
