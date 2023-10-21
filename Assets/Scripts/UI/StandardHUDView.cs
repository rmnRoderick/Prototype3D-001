using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StandardHUDView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lifeText;

    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private const string BASE_LIFE_TEXT = "Life: ";
    private const string BASE_TIME_TEXT = "TIME: ";
    private const string BASE_SCORE_TEXT = "Score: ";

    [SerializeField] private UIEventController _uiEventController;
    void Start()
    {
        _uiEventController.OnUpdateLifeHUD += UpdateLifeText;
        _uiEventController.OnUpdateTimeHUD += UpdateTimeText;
        _uiEventController.OnUpdateScoreHUD += UpdateScoreText;
    }

    private void UpdateLifeText(string life) => _lifeText.text = BASE_LIFE_TEXT + life;
    private void UpdateTimeText(string time) => _timeText.text = BASE_TIME_TEXT + time;
    private void UpdateScoreText(string score) => _scoreText.text = BASE_SCORE_TEXT + score;
    
}
