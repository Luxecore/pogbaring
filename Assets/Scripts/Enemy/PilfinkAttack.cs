using UnityEngine;

public class PilfinkAttack : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyData enemyData;

    
    public int pilfinkHealth;

   
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject shootPoint;

    [SerializeField] GameObject xpShard;
     float attackRange;
     float fireRate = 2f;
     

    Transform target;
    float nextFireTime;

    void Start()
    {
        pilfinkHealth = enemyData.health;

        target = GameObject.Find("Pogba").transform;

        attackRange = enemyData.range;
    }

    void Update()
    {
        if (pilfinkHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(xpShard, transform.position, Quaternion.identity);
           
            
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        // Check if player is within attack range
        if (distance <= attackRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            Vector3 direction =
                (target.position - shootPoint.transform.position).normalized;

            GameObject projectile = Instantiate(
                projectilePrefab,
                shootPoint.transform.position,
                Quaternion.identity
            );

            Projectile projectileScript = projectile.GetComponent<Projectile>();

            projectileScript.SetDirection(direction);
        }
    }

    public void TakeDmg(int damage)
    {
        pilfinkHealth -= damage;
    }
}