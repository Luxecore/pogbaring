using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    XPbar healthMulti;

    private void Start()
    {
        healthMulti = GameObject.FindGameObjectWithTag("XPBar").GetComponent<XPbar>();

        StartCoroutine(HealthRegen());
    }

    IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (health < maxHealth)
            {
                health = Mathf.Min(health + 2f, maxHealth);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        FindAnyObjectByType<WorldTimer>().SaveScore();
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        maxHealth = 100f * healthMulti.healthMulti;
        health = Mathf.Min(health, maxHealth);

       
    }
}