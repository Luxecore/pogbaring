using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    EnemyData _enemyData;
    public int health = 100;
   

    public void TakeDamage(int damage)
    {
       
        health -= damage;
        Debug.Log("Player took " + damage + "damage");

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died!");
    }
}
