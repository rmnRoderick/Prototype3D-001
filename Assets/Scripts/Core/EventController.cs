using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core
{
    public class EventController : ISuscriber, INotifier
    {
        public enum UIEventType
        {
            UpdateLifeEvent,
            AddScoreEvent,
            LifeEvent,
            ScoreEvent,
            TimeEvent,
        }

        private Dictionary<UIEventType, List<object>> _suscribers = new ();

        public void Subscribe(object listener, UIEventType eventType)
        {
            if(!_suscribers.ContainsKey(eventType) || _suscribers[eventType] == null)
                _suscribers.Add(eventType, new List<object>());
        
            _suscribers[eventType].Add(listener);
        }

        public void UnSubscribe(object listener, EventController.UIEventType eventType)
        {
            _suscribers[eventType].Remove(listener);
        }
    
        public void Notify<T>(EventController.UIEventType type, T data)
        {
            //evitar si no hay listeners
            if (_suscribers.ContainsKey(type)){
                foreach (IListener specificSuscriber  in _suscribers[type])
                {
                    specificSuscriber.UpdateData(type, data);
                }
            } 
        }

        public event Action<string, string> OnShowPanel;
        public event Action OnHidePanel;
    
    }

    public interface INotifier
    {
        public void Notify<T>(EventController.UIEventType type, T  data);

    }

    public interface IListener
    {
        void UpdateData<T>(EventController.UIEventType type, T data);
    }
}