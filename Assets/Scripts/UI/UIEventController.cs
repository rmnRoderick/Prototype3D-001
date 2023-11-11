using System;
using System.Collections.Generic;

public class UIEventController<T>: ISuscriber, INotifier
{
    public enum UIEventType
    {
        LooseLifeEvent,
        AddLifeEvent,
        AddScoreEvent,
        LifeEvent,
        ScoreEvent,
        TimeEvent,
    }

    private Dictionary<UIEventType, List<object>> _suscribers = new ();

    public void Subscribe<T>(object listener, T eventType)
    {
        if(!_suscribers.ContainsKey(eventType) || _suscribers[eventType] == null)
            _suscribers.Add(eventType, new List<object>());
        
        _suscribers[eventType].Add(listener);
    }

    public void UnSubscribe<T>(object listener, T eventType)
    {
        _suscribers[eventType].Remove(listener);
    }
    
    public void Notify<T>(UIEventType type, T data)
    {
        foreach (IListener specificSuscriber  in _suscribers[type])
        {
            specificSuscriber.UpdateData(type, data);
        }
    }
    
    public event Action<string, string> OnShowPanel;
    public event Action OnHidePanel;
    
}

public interface INotifier
{
    public void Notify<T>(UIEventController<T>.UIEventType type, T data);

}

public interface ISuscriber
{
    public void Subscribe<T>(object listener, UIEventController<T>.UIEventType eventType);
    public void UnSubscribe<T>(object listener, UIEventController<T>.UIEventType eventType);
}

public interface IListener
{
    void UpdateData<T>(UIEventController<T>.UIEventType type, T data);
}

