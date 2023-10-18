using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerInstaller : MonoBehaviour
    {
        [SerializeField] private Player player;
        private KeyboardInput kbInput;

        void Awake()
        {
            player.Configure(new KeyboardInput());
        }

    }
}