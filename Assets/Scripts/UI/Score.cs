using TMPro;
using UnityEngine;

public class Score
{
    private TextMeshProUGUI scoreText;
    private float score = 0;

    public Score(TextMeshProUGUI scoreText)
    {
        this.scoreText = scoreText;
    }

    public void addScore(float _score)
    {
        score += _score;
    }
    public void RefreshScore()
    {
        scoreText.SetText("Score: " + score);
    }

}
