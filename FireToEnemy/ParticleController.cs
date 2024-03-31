using UnityEngine;

public class ParticleController : MonoBehaviour
{ 
    public int range;
    public int damage;

    private ParticleSystem particleSystem;
    private float curCooldown = .3f;
    private float cDown = .3f;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop(true);
    }

    private void Update()
    {
        curCooldown -= Time.deltaTime;
        curCooldown = Mathf.Max(curCooldown, 0f);

        if (curCooldown <= 0)
        {
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
                particleSystem.Play(true);
                nearestEnemy.GetComponent<DamageScript>().TakeDamage(damage);
                transform.LookAt(nearestEnemy);
            }
            else
            {
                particleSystem.Stop(true);
            }

            curCooldown = cDown;
        }
    }
}