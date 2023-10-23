using TMPro;
using UnityEngine;

public class Timer
{
    private float _maxTime;

    private INotifier _notifier;

    public Timer(float maxTime)
    {
        _notifier = Installer.instance.GetEventController();
        _maxTime = maxTime;
    }

    public void RefreshTime()
    {
        if (_maxTime <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Timeout");
        }
        else
        {
            _maxTime -= Time.deltaTime;
        }
        //timeText.SetText("Time: " + Mathf.Round(maxTime));
        _notifier.Notify(UIEventController.UIEventType.TimeEvent, Mathf.Round(_maxTime));
    }

    public float getRemainingTime() => _maxTime;

}
