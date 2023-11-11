using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float maxTime;
        [SerializeField] private int score;
        [SerializeField] private int lifes;

        private Score _score;
        private Life _life;
        private Timer _timer;

        private UIEventController _eventController;
        
        void Start()
        {
            _eventController = Installer.instance.GetEventController();

            _score = new(_eventController,score);
            _timer= new(maxTime);
            _life = new(_eventController,lifes);

            //player.Configure( GetInput());
            player.Configure(GetInput(), _score, _life);
        }

        private void Update()
        {
            _timer.RefreshTime();
        }

        private IInput GetInput()
        {
            return new KeyboardInput();
        }

    }
}