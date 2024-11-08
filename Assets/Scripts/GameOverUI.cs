using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        //display the final score on game over scene
        scoreText.text = "Final Score: " + TimeController.finalScore.ToString();

    }
}
