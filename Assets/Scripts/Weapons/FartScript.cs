using UnityEngine;

public class FartScript : MonoBehaviour
{

    [SerializeField] ProjectileData projectileData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();

            if (enemy != null)
            {
                enemy.TakeDmg(projectileData.damage);
              
            }
        }
    }
}
