public class Life: IListener
{
    private int _lifes;
    private INotifier _eventController;
    private ISuscriber _subscriberController;

    public Life(UIEventController eventController, int lifes = 3)
    {
        _lifes = lifes;
        _eventController = eventController;
        _subscriberController = eventController;

        _subscriberController.Subscribe(this, UIEventController.UIEventType.UpdateLifeEvent);

    }

    public void updateLife(int lifes)
    {
        _lifes += lifes;
        _eventController.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
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
