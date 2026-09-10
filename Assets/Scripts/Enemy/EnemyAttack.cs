using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
