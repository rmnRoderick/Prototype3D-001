public class Life: IListener
{
    private int _lifes;
    private INotifier _notifier;
    private ISuscriber _subscriberController;

    public Life(UIEventController eventController, int lifes)
    {
        _lifes = lifes;
        _notifier = eventController;
        _subscriberController = eventController;

        _subscriberController.Subscribe(this, UIEventController.UIEventType.UpdateLifeEvent);
        _notifier.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
    }

    public void updateLife(int lifes)
    {
        _lifes += lifes;
        _notifier.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
    }

    //public void LooseLife()
    //{
    //    _lifes--;
    //    _eventController.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
    //}     
    public int getRemainingLifes()=>_lifes;


    public void UpdateData<T>(UIEventController.UIEventType type, T data)
    {
        updateLife(int.Parse(data.ToString()));
    }


}
