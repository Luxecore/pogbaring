using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;

    [SerializeField] float speed = 10f;
    [SerializeField] EnemyData _enemyData;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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