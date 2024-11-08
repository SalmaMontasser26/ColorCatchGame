using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float gameTime = 120f;
    public TextMeshProUGUI timerText;
    private float remainingTime;
    public static int finalScore;

    void Start()
    {
        remainingTime = gameTime;
    }
    //time decreases with deltatime
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            GameOver();
        }
    }
    //update the timer text on screen
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    //set the score on screen
    public static void SetFinalScore(int score)
    {
        finalScore = score;
    }
    //when timer is up,save the final score and load to game over scene
    void GameOver()
    {
        SetFinalScore(ScoreController.Instance.score);
        //GameManager.SetFinalScore(ScoreController.Instance.score);
        SceneManager.LoadScene(2);
    }
}
