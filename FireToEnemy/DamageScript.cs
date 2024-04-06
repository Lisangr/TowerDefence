using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int HP; 
    public int maxHP; 

    public delegate void DeathAction();
    public static event DeathAction OnEnemyDeath;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            OnEnemyDeath?.Invoke();
        }
    }
}
