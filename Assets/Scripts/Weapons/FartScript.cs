using UnityEngine;

public class FartScript : MonoBehaviour
{
    XPbar dmgMulti;
    [SerializeField] ProjectileData projectileData;

    float dmg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dmgMulti = GameObject.FindGameObjectWithTag("XPBar").GetComponent<XPbar>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -25f * Time.deltaTime);
        dmg = projectileData.damage * dmgMulti.dmgMulti;
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();

            if (enemy != null)
            {
                enemy.TakeDmg(dmg);
              
            }
        }
    }
}
