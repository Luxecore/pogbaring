using UnityEngine;

public class PukeScript : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, projectileData.projectileLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
