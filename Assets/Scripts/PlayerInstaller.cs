using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        public GameState gameState;

        private Score _score;
        private Life _life;

        private UIEventController _eventController;
        
        void Start()
        {
            _eventController = Installer.instance.GetEventController();

            _score = new(_eventController);

            _life = new(_eventController);

            //player.Configure( GetInput());
            player.Configure(GetInput(), _score, _life);
        }

        private IInput GetInput()
        {
            return new KeyboardInput();
        }

    }
}