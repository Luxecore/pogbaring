using UnityEngine;

public class SkataAttack : MonoBehaviour , IDamageable
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] GameObject xpShard;
    public float skataHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skataHealth  = _enemyData.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(skataHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(xpShard, transform.position, Quaternion.identity);


        }
    }

    public void TakeDmg(float damage)
    {
       skataHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Pogba"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(_enemyData.damage);
            }
        }
    }
}
