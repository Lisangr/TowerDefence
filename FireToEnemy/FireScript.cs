using System.Collections;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private float range = 50f;
    private float coolDown = 1f;
    private float currentCooldown = 0f;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (CanShoot())
        {
            SearchTarget();
        }

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    private bool CanShoot()
    {
        return currentCooldown <= 0;
    }

    private void SearchTarget()
    {
        currentCooldown = coolDown;

        Transform nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (currentDistance < nearestDistance && currentDistance <= range)
            {
                nearestEnemy = enemy.transform;
                nearestDistance = currentDistance;
            }
        }

        if (nearestEnemy != null)
        {
            Shoot(nearestEnemy);
        }
    }

    private void Shoot(Transform enemy)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetTarget(enemy);
    }
}
