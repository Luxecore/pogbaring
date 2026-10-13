using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{

   [SerializeField] float xpNeeded;
  public float currentXp;
    [SerializeField] TextMeshProUGUI currentLvLText;
    int currentLevel;
   [SerializeField] Image xpBar;
    [SerializeField] GameObject lvlUpUI;

    [SerializeField]GameObject Fart;

    [SerializeField] GameObject Marlie;

    public float dmgMulti = 1f;
    public float healthMulti = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpNeeded = 5;
        currentXp = 0;
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {

        currentLvLText.text = ("Lvl: " + currentLevel);
        if (currentXp >= xpNeeded)
        {
            currentXp = 0f;
            xpNeeded *= 1.5f;
            Time.timeScale = 0f;
            lvlUpUI.SetActive(true);
        }


        xpBar.fillAmount = currentXp / xpNeeded;

        if (currentLevel >= 3)
        {
            Fart.SetActive(true);
        }
        if (currentLevel >= 6)
        {
            Marlie.SetActive(true);
        }

    }

    public void DamageUp()
    {
        Time.timeScale = 1f;
        lvlUpUI.SetActive(false);
        dmgMulti *= 1.1f;
        currentLevel += 1;
    }

    public void HealthUp()
    {
        Time.timeScale = 1f;
        lvlUpUI.SetActive(false);
        healthMulti *= 1.1f;
        currentLevel += 1;
    }
}
