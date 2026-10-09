using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{

   [SerializeField] float xpNeeded;
  public float currentXp;
   [SerializeField] Image xpBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpNeeded = 5;
        currentXp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentXp >= xpNeeded)
        {
            currentXp = 0f;
            xpNeeded *= 1.5f;
        }


        xpBar.fillAmount = currentXp / xpNeeded;
    }
}
