using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] float speed = 10f;

    [SerializeField] EnemyData _enemyData;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
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