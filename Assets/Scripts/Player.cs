using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Controllers
{



    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update

        [Header("condiguracion")]
        [SerializeField] float jumpForce = 10f;
        [SerializeField] float speed = 150f;
        [SerializeField] Rigidbody rb;
        [SerializeField] private int lifes;
        private Health health;

        private Transform _transform;
        private Vector3 initialPosition;

        //GameObject player=null;
        private int jumps = 0;

        private float horizontalInput;
        private float verticalInput;
        private Vector3 movement;

        private IInput input = null;

        private bool onGround = true;

        private float fallingTime = 0;

        private void Awake()
        {
            _transform = transform;
            rb = gameObject.GetComponent<Rigidbody>();
            health = gameObject.GetComponent<Health>();
        }

        void Start()
        {

            initialPosition=transform.position; 

        }

        public void Configure(IInput _input)
        {
            input = _input;
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("ground"))
            {
                onGround = true;
                fallingTime = 0f;
                jumps = 0;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                onGround = false;
            }
        }


        // Update is called once per frame
        void Update()
        {

            //salto // doble salto
            if (Input.GetKeyUp(KeyCode.Space) && jumps < 2)
            {
                jumps++;
                Vector3 salto = new Vector3(0, jumpForce, 0);
                rb.AddForce(salto, ForceMode.Impulse);
                Debug.Log("salto");
            }


            //si esta en el suelo
            if (onGround)
            {
                if (input != null)
                {
                    rb.AddForce(speed * input.GetMovement(), ForceMode.Force);
                }
            }
            else
            {

                fallingTime += Time.deltaTime;

                if (fallingTime > 5f)
                {
                    //Destroy(gameObject);

                    health.LooseLife();
                    _transform.position = initialPosition;
                    fallingTime = 0;

                    if (health.gameOver)
                    {
                        Time.timeScale = 0f;
                        GameObject.Find("Main Camera").transform.parent = null;
                        Debug.Log("Game Over");
                    }
                }

            }


        }


    }

}