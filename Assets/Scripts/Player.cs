using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    //GameObject player=null;
    private Rigidbody rb = null;
    private int jumps = 0;
    [SerializeField] float jumpForce =10f;
    [SerializeField] float speed =150f;

    private bool onGround = true;
    
    void Start()
    {
        
         rb = gameObject.GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        jumps = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }


    // Update is called once per frame
    void Update()
    {

        //si esta en el suelo
        if( onGround)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

            //salto
            if (Input.GetKeyUp(KeyCode.Space) && jumps <2)
            {
                jumps++;

                Vector3 salto = new Vector3(0, jumpForce, 0);

                rb.AddForce(salto, ForceMode.Impulse);

                Console.WriteLine("salto");
            }

            rb.AddForce(speed * Time.deltaTime * movement ,  ForceMode.Force);


        }
        else
        {

            if (gameObject.transform.position.y < -5f)
            {
                GameObject.Find("Main Camera").transform.parent = null;
                Destroy(gameObject);
                Console.WriteLine("game over");
            }

        }


    }


}
