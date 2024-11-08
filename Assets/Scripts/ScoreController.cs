using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public static ScoreController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //update score at the beginning of the game
    void Start()
    {
        UpdateScoreText();
    }

    //change score based on given points (1,-1)
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    //update the score on display
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
