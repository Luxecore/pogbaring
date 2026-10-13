using UnityEngine;

public class hedgehogAttack : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyData _enemyData;
    [SerializeField] GameObject xpShard;
    public float hedgehogHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hedgehogHealth = _enemyData.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (hedgehogHealth <= 0) 
        {
            Destroy(gameObject);
            Instantiate(xpShard, transform.position, Quaternion.identity);


        }
    }

    public void TakeDmg(float damage)
    {
        hedgehogHealth -= damage;
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
