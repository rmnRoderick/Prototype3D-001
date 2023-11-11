using Core;
using Core.Interfaces;

namespace UI.Models
{
    public class Score : IListener
    {
        private float _score = 0;
        private readonly INotifier _notify;
        private readonly ISuscriber _subscriberController;

        public Score(EventController eventController, int score = 0)
        {
            _score = score;
            _notify = eventController;
            _subscriberController = eventController;

            _subscriberController.Subscribe(this, EventController.UIEventType.AddScoreEvent);
                
            _notify.Notify(EventController.UIEventType.ScoreEvent, _score);
        }
        public void addScore(float score)
        {
            _score += score;
            _notify.Notify(EventController.UIEventType.ScoreEvent, _score);
        }

        public string RefreshScore()=> "Score: " + _score;

        public void UpdateData<T>(EventController.UIEventType type, T data)
        {
            addScore(float.Parse(data.ToString()));
        }
    }
}
