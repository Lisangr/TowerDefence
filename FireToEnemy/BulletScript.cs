using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public int damage = 10;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) < .2f)
            {
                target.GetComponent<DamageScript>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Vector3 dir = target.position - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
            Destroy(gameObject);
    }
}
