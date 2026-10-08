using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

   

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
        FindAnyObjectByType<WorldTimer>().SaveScore();
        SceneManager.LoadScene(0);
    }
}
