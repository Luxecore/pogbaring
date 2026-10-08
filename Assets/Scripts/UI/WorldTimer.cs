using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public float time;

    private const string HighScoreKey = "BestTime";

    void Start()
    {
        UpdateHighScoreText();
    }

    void Update()
    {
        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Player survives until 10 minutes
        if (time >= 600f)
        {
            SaveScore();
            SceneManager.LoadScene(0);
        }
    }

    public void SaveScore()
    {
        float bestTime = PlayerPrefs.GetFloat(HighScoreKey, 0f);

        if (time > bestTime)
        {
            PlayerPrefs.SetFloat(HighScoreKey, time);
            PlayerPrefs.Save();

            Debug.Log("NEW BEST TIME: " + time);
        }
    }

    void UpdateHighScoreText()
    {
        float bestTime = PlayerPrefs.GetFloat(HighScoreKey, 0f);

        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);

        highScoreText.text = string.Format(
            "BEST: {0:00}:{1:00}",
            minutes,
            seconds
        );
    }
}