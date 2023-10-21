using System;
using UnityEngine;

namespace Controllers
{
    public class Installer : MonoBehaviour
    {
        public static Installer instance;
        private UIEventController _uiEventController;
        [SerializeField] private StandardHUDView _standardHUDView;

        private void Awake()
        {
            if(instance == null)
                instance = this;
            
            _uiEventController = new();
 
        }
        public UIEventController GetEventController() => _uiEventController;
    }
}