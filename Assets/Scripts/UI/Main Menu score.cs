using TMPro;
using UnityEngine;

public class MainMenuHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    private const string HighScoreKey = "BestTime";

    void Start()
    {
        DisplayHighScore();
    }

    void DisplayHighScore()
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