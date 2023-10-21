using System;
using System.Collections.Generic;

public class UIEventController : ISuscriber
{
    public Action<string, string> OnShowPanel;
    public Action OnHidePanel;

    public enum UIEventType
    {
        LifeEvent,
        ScoreEvent,
        TimeEvent,
    }

    private Dictionary<UIEventType, List<object>> _suscribers = new ();

    public void Suscribe(object listener, UIEventType eventType)
    {
        if(!_suscribers.ContainsKey(eventType) || _suscribers[eventType] == null)
            _suscribers.Add(eventType, new List<object>());
        
        _suscribers[eventType].Add(listener);
    }

    public void UnSuscribe(object listener, UIEventType eventType)
    {
        _suscribers[eventType].Remove(listener);
    }

    public void Notify(UIEventType type, string data)
    {
        foreach (INotificator specificSuscriber  in _suscribers[type])
        {
            specificSuscriber.SendData(data);
        }
    }
}

public interface ISuscriber
{
    public void Suscribe(object listener, UIEventController.UIEventType eventType);
    public void UnSuscribe(object listener, UIEventController.UIEventType eventType);
}

public interface INotificator
{
    void SendData(string data);
}

