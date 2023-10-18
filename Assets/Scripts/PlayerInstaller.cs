using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        public GameState gameState;

        void Awake()
        {
            
            player.Configure( GetInput(), gameState);
        }

        private IInput GetInput()
        {
            return new KeyboardInput();
        }

    }
}