using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    //GameObject player=null;
    private int jumps = 0;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;

    [SerializeField] float jumpForce =10f;
    [SerializeField] float speed =150f;
    [SerializeField] Rigidbody rb;

    private bool onGround = true;
    
    void Start()
    {
        
         rb = gameObject.GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
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
        if (Input.GetKeyUp(KeyCode.Space) && jumps < 2 )
        {
            jumps++;
            Vector3 salto = new Vector3(0, jumpForce, 0);
            rb.AddForce(salto, ForceMode.Impulse);
            Debug.Log("salto");
        }


        //si esta en el suelo
        if ( onGround )
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            movement = new Vector3(horizontalInput, 0, verticalInput);
            rb.AddForce(speed * Time.deltaTime * movement ,  ForceMode.Force);
        }
        else
        {

            if (gameObject.transform.position.y < -5f)
            {
                GameObject.Find("Main Camera").transform.parent = null;
                //Destroy(gameObject);
                
                Debug.Log("game over");
            }

        }


    }


}
