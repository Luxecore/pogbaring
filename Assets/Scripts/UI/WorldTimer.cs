using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WorldTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float time;

    public int minutes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
         minutes = Mathf.FloorToInt(time / 60); 
        int seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format(
            "{0:00}:{1:00}",
            minutes,
            seconds
        );


        if (minutes >= 10)
            SceneManager.LoadScene(0);
    }
}
