using UnityEngine;

public class XPShard : MonoBehaviour
{

    XPbar xpGain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpGain = GameObject.FindGameObjectWithTag("XPBar").GetComponent<XPbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            xpGain.currentXp += 2;
            Destroy(gameObject);
        }
    }
}
