using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    PlayerHealth playerHealth;

    [SerializeField] Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth.health / 100f;
        
    }
}
