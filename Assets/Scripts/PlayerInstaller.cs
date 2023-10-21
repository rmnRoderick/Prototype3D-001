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
        
        void Awake()
        {
            _score = new(Installer.instance.GetEventController());
            _life = new(Installer.instance.GetEventController());
            
            player.Configure( GetInput(), _score,_life);
        }

        private IInput GetInput()
        {
            return new KeyboardInput();
        }

    }
}