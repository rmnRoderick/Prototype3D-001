using System;
using System.Collections.Generic;
using Controllers;
using TMPro;
using UnityEngine;



public class StandardHUDView : MonoBehaviour, IListener
{
    [SerializeField] private TextMeshProUGUI _lifeText;

    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private const string BASE_LIFE_TEXT = "Life: ";
    private const string BASE_TIME_TEXT = "TIME: ";
    private const string BASE_SCORE_TEXT = "Score: ";

    private ISuscriber _uiEventController;

    private Dictionary<UIEventController.UIEventType, Action<string>> actionTypes = new();
    private void Start()
    {
        _uiEventController = Installer.instance.GetEventController();
        _uiEventController.Subscribe(this, UIEventController.UIEventType.LifeEvent);
        _uiEventController.Subscribe(this, UIEventController.UIEventType.ScoreEvent);
        _uiEventController.Subscribe(this, UIEventController.UIEventType.TimeEvent);
            
        actionTypes.Add(UIEventController.UIEventType.LifeEvent, (data) => UpdateLifeText(data));
        actionTypes.Add(UIEventController.UIEventType.ScoreEvent, (data) => UpdateScoreText(data));
        actionTypes.Add(UIEventController.UIEventType.TimeEvent, (data) => UpdateTimeText(data));
    }
    private void OnDestroy()
    {
        _uiEventController.UnSubscribe(this, UIEventController.UIEventType.LifeEvent);
        _uiEventController.UnSubscribe(this, UIEventController.UIEventType.ScoreEvent);
        _uiEventController.UnSubscribe(this, UIEventController.UIEventType.TimeEvent);
    }

    private void UpdateLifeText<T>(T life) => _lifeText.text = BASE_LIFE_TEXT + life;
    private void UpdateTimeText<T>(T time) => _timeText.text = BASE_TIME_TEXT + time;
    private void UpdateScoreText<T>(T score) => _scoreText.text = BASE_SCORE_TEXT + score;

    public void UpdateData<T>(UIEventController.UIEventType type, T data)
    {
        actionTypes[type]?.Invoke(data.ToString());
    }
}
