public class Lifes 
{
    private int _lifes;
    private UIEventController _eventController;

    public Lifes(int lifes)=>this._lifes = lifes;

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


}
