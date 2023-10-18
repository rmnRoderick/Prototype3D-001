using TMPro;
using UnityEngine;

public class Timer
{
    private float maxTime;
    public bool gameOver;

    private TextMeshProUGUI timeText;

    public Timer(float maxTime, TextMeshProUGUI timeText)
    {
        this.maxTime = maxTime;
        this.timeText = timeText;
    }

    public void RefreshTime()
    {
        if (maxTime <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Timeout");
        }
        else
        {
            maxTime -= Time.deltaTime;
        }
        timeText.SetText("Time: " + Mathf.Round(maxTime));
    }

    public float getRemainingTime()
    {
        return maxTime;
    }

}
