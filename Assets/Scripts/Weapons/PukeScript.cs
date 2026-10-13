using UnityEngine;

public class PukeScript : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;
    XPbar dmgMulti;

    float dmg;
    void Start()
    {
        Destroy(gameObject, projectileData.projectileLifetime);

        dmgMulti = GameObject.FindGameObjectWithTag("XPBar").GetComponent<XPbar>();

        dmg = projectileData.damage * dmgMulti.dmgMulti;
    }
    private void Update()
    {
        dmg = projectileData.damage * dmgMulti.dmgMulti;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();

            if (enemy != null)
            {
                enemy.TakeDmg(dmg);
                Destroy(gameObject);
            }
        }
    }
}