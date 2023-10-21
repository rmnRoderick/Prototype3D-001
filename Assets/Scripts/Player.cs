using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;




    public class Player : MonoBehaviour
    {
        // Start is called before the first frame update

        [Header("condiguracion")]
        [SerializeField] float jumpForce = 10f;
        [SerializeField] float speed = 150f;
        [SerializeField] Rigidbody rb;
        [SerializeField] private float offsetY;


        private GameObject lastPlatform;
        public bool gameOver { get; private set; }

        //        [SerializeField] private int Life;
        private Transform _transform;
        private Vector3 initialPosition;

        //GameObject player=null;
        private int jumps = 0;

        private IInput input = null;

        private bool onGround = true;

        private float fallingTime = 0;

        private Score _score;
        private Life _life;

        private void Awake()
        {
            _transform = transform;
            rb = gameObject.GetComponent<Rigidbody>();
            
            
        }

        void Start()
        {

            initialPosition=transform.position;
                    //offsetY = lastPlatform.transform.position.y - initialPosition.y;

        }

        public void Configure(IInput _input, Score score, Life life )
        {
            input = _input;
            _score = score;
            _life = life;
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickeableObject"))
        {

            IPickeableObject pickableObject = other.GetComponent<IPickeableObject>();

            pickableObject.Pickup();

        }
    }

    private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("ground"))
            {
                onGround = true;
                fallingTime = 0f;
                jumps = 0;

                lastPlatform = collision.gameObject;

               //gameState.score.addScore(lastPlatform.GetComponent<Platform>().GetScore());

                gameObject.transform.parent = collision.transform;

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
            }


            //si esta en el suelo
            if (onGround)
            {
                if (input != null)
                {
                    rb.AddForce(speed * input.GetMovement().normalized, ForceMode.Force);
                }
            }
            else
            {

                fallingTime += Time.deltaTime;

                if (fallingTime > 5f)
                {
                    //Destroy(gameObject);

                    _life.LooseLife();
                    var newPosition = lastPlatform.transform.position;
                    newPosition.y += offsetY;

                    _transform.position = newPosition;
                    fallingTime = 0;

                }
            }

            if (_life.getRemainingLifes() <= 0);
            {
                Time.timeScale = 0f;
                GameObject.Find("Main Camera").transform.parent = null;
                Debug.Log("Game Over");
            }



    }


}

