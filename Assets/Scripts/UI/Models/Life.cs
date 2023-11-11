using Core;
using Core.Interfaces;

namespace UI.Models
{
    public class Life: IListener
    {
        private int _lifes;
        private INotifier _notifier;
        private ISuscriber _subscriberController;

        public Life(EventController eventController, int lifes)
        {
            _lifes = lifes;
            _notifier = eventController;
            _subscriberController = eventController;

            _subscriberController.Subscribe(this, EventController.UIEventType.UpdateLifeEvent);
            _notifier.Notify(EventController.UIEventType.LifeEvent, _lifes.ToString());
        }

        public void updateLife(int lifes)
        {
            _lifes += lifes;
            _notifier.Notify(EventController.UIEventType.LifeEvent, _lifes.ToString());
        }
        public int getRemainingLifes()=>_lifes;


        public void UpdateData<T>(EventController.UIEventType type, T data)
        {
            updateLife(int.Parse(data.ToString()));
        }


    }
}
