using Core;
using UnityEngine;

public class Installer : MonoBehaviour
{
    public static Installer instance;
    private EventController _eventController;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            _eventController = new EventController();
        }
        else
        {
            Destroy(gameObject);
        }
 
    }
    public EventController GetEventController() => _eventController;
}
