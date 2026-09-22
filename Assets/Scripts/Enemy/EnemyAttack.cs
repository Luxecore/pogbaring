using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;

    public int enemyHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth  = _enemyData.health;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0) 
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("den träffade");
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
