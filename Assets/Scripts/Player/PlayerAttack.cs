using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    List<GameObject>Enemies = new List<GameObject>();

    [SerializeField] ProjectileData _projectileData;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform pogbaShoot;

   public GameObject closestEnemy;

    float shootTimer;

    GameObject enemyToShootAt;
    


    // Update is called once per frame
    void Update()
    {
        AddEnemiesToList();
        FindClosestEnemy();

     shootTimer -= Time.deltaTime;
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
        //Can't shoot if enemy isn't in the list
        if(enemyToShootAt == null)
            return;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector2 direction = (enemyToShootAt.transform.position - pogbaShoot.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * _projectileData.projectileSpeed;
    }
}
