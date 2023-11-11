using Core;
using UnityEngine;

namespace Pickeables
{
    public class ScoreObject : MonoBehaviour, IPickeableObject
    {
        public float score;

        [SerializeField] private ParticleSystem particlePrefab;
        private INotifier _eventController;

        private void Start()
        {
            _eventController = Installer.instance.GetEventController();
        }

        public void Pickup()
        {
            _eventController.Notify(EventController.UIEventType.AddScoreEvent, score);
            score = 0;
        
            var particleSys = Instantiate(particlePrefab,transform.position,transform.rotation);
            Destroy(gameObject);
        
        

            particleSys.Play();
            Destroy(particleSys,.5f);
        }


    }
}

