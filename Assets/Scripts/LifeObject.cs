using Controllers;
using UnityEngine;

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
        //_eventController.Notify(UIEventController.UIEventType.LifeEvent, lifes.ToString());
        _eventController.Notify(UIEventController.UIEventType.AddLifeEvent, lifes);
        lifes = 0;
        
        var particleSys = Instantiate(particlePrefab,transform.position,transform.rotation);
        Destroy(gameObject);

        particleSys.Play();
        Destroy(particleSys,.5f);
    }


}

