using Core;
using UnityEngine;

namespace Pickeables
{
    public class LifeObject : MonoBehaviour, IPickeableObject
    {
        public int lifes;

        [SerializeField] private ParticleSystem particlePrefab;
        private INotifier _eventController;
        private void Start()
        {
            _eventController = Installer.instance.GetEventController();
        }
        public void Pickup()
        {
            //_eventController.Notify(EventController.UIEventType.LifeEvent, lifes.ToString());
            _eventController.Notify(EventController.UIEventType.UpdateLifeEvent, lifes);
            lifes = 0;
        
            var particleSys = Instantiate(particlePrefab,transform.position,transform.rotation);
            Destroy(gameObject);

            particleSys.Play();
            Destroy(particleSys,.5f);
        }


    }
}

