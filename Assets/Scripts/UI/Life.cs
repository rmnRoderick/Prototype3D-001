public class Life: IListener
{
    private int _lifes;
    private INotifier _eventController;

    public Life(INotifier eventController, int lifes = 3)
    {
        _lifes = lifes;
        _eventController = eventController;
    }

    public void addLife(int lifes = 1)
    {
        _lifes += lifes;
        _eventController.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
    }

    public void LooseLife()
    {
        _lifes--;
        _eventController.Notify(UIEventController.UIEventType.LifeEvent, _lifes.ToString());
    }     
    public int getRemainingLifes()=>_lifes;


    public void UpdateData(UIEventController.UIEventType type, string data)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateData(UIEventController.UIEventType type, int data)
    {
        
    }
}
