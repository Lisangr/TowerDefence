using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int HP; //здоровье
    public int maxHP; // максимальное здоровье

    //public delegate void DeathAction();
    //public static event DeathAction OnEnemyDeath;

    public void TakeDamage(int damage) //«доровье - урон
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            //OnEnemyDeath?.Invoke();
        }
    }
}
