using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player=null;
    Rigidbody rb = null;

    void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Console.Write(verticalInput + "\n");

        rb.AddForce(new Vector3.up(verticalInput),ForceMode.Impulse);
            
    }


}
