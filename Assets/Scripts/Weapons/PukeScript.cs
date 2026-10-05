using UnityEngine;

public class PukeScript : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;

    void Start()
    {
        Destroy(gameObject, projectileData.projectileLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();

            if (enemy != null)
            {
                enemy.TakeDmg(projectileData.damage);
                Destroy(gameObject);
            }
        }
    }
}