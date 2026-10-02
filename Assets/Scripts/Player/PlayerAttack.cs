using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    List<GameObject>Enemies = new List<GameObject>();

    [SerializeField]  ProjectileData _projectileData;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform pogbaShoot;

   public GameObject closestEnemy;

     float shootTimer;

    GameObject enemyToShootAt;

    [SerializeField] Image pukeCooldown;

    // Update is called once per frame
    void Update()
    {
        AddEnemiesToList();
        FindClosestEnemy();

        shootTimer -= Time.deltaTime;
        pukeCooldown.fillAmount = 1f - (shootTimer / _projectileData.projectileRate);
        if (closestEnemy != null && shootTimer <= 0f)
        {
            ShootProjectile();
            shootTimer = _projectileData.projectileRate;
        }

        
    }
    //Visar bara range
    private void OnDrawGizmos()
    { Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _projectileData.range);
    }
   
    void AddEnemiesToList()
    {
        GameObject[] FoundEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in FoundEnemy)
        {
            if (enemy != null && !Enemies.Contains(enemy))
                Enemies.Add(enemy);
            
                
        }
    }

    void FindClosestEnemy()
    {
         closestEnemy = null;
         enemyToShootAt = null;
        float closestDistance = _projectileData.range;

        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            if (Enemies[i] == null) Enemies.RemoveAt(i);
        }

        foreach(GameObject enemy in Enemies)
        {
            //Kolla in på hur man tar bort ett object från en lista (detta är inte optimiserat)
            if(enemy == null)
            {
                Enemies.Remove(enemy);
                
            }
            float distanceFromEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceFromEnemy < closestDistance)
            {

                closestDistance = distanceFromEnemy;
                closestEnemy = enemy;
                enemyToShootAt = closestEnemy;
            
            }
        }
    }

    void ShootProjectile()
    {
        if (enemyToShootAt == null)
            return;

        Vector2 direction = (enemyToShootAt.transform.position - pogbaShoot.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(
            projectilePrefab,
            transform.position,
            rotation
        );

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * _projectileData.projectileSpeed;
    }
}
