using System;
using System.Collections.Generic;
using Core;
using Core.Interfaces;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StandardHUDView : MonoBehaviour, IListener
    {
        [SerializeField] private TextMeshProUGUI _lifeText;

        [SerializeField] private TextMeshProUGUI _timeText;

        [SerializeField] private TextMeshProUGUI _scoreText;

        private const string BASE_LIFE_TEXT = "Life: ";
        private const string BASE_TIME_TEXT = "TIME: ";
        private const string BASE_SCORE_TEXT = "Score: ";

        private ISuscriber _uiEventController;

        private Dictionary<EventController.UIEventType, Action<string>> actionTypes = new();
        private void Start()
        {
            _uiEventController = Installer.instance.GetEventController();
            _uiEventController.Subscribe(this, EventController.UIEventType.LifeEvent);
            _uiEventController.Subscribe(this, EventController.UIEventType.ScoreEvent);
            _uiEventController.Subscribe(this, EventController.UIEventType.TimeEvent);
            
            actionTypes.Add(EventController.UIEventType.LifeEvent, (data) => UpdateLifeText(data));
            actionTypes.Add(EventController.UIEventType.ScoreEvent, (data) => UpdateScoreText(data));
            actionTypes.Add(EventController.UIEventType.TimeEvent, (data) => UpdateTimeText(data));
        }
        private void OnDestroy()
        {
            _uiEventController.UnSubscribe(this, EventController.UIEventType.LifeEvent);
            _uiEventController.UnSubscribe(this, EventController.UIEventType.ScoreEvent);
            _uiEventController.UnSubscribe(this, EventController.UIEventType.TimeEvent);
        }

        private void UpdateLifeText<T>(T life) => _lifeText.text = BASE_LIFE_TEXT + life;
        private void UpdateTimeText<T>(T time) => _timeText.text = BASE_TIME_TEXT + time;
        private void UpdateScoreText<T>(T score) => _scoreText.text = BASE_SCORE_TEXT + score;

        public void UpdateData<T>(EventController.UIEventType type, T data)
        {
            actionTypes[type]?.Invoke(data.ToString());
        }
    }
}
