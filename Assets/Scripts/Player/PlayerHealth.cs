using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    EnemyData _enemyData;
    public int health = 100;
   

    public void TakeDamage(int damage)
    {
       
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}
