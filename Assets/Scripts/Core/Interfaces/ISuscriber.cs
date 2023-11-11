namespace Core.Interfaces
{
    public interface ISuscriber
    {
        public void Subscribe(object listener, EventController.UIEventType eventType);
        public void UnSubscribe(object listener, EventController.UIEventType eventType);
    }
}