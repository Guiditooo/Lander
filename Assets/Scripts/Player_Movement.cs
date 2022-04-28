using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float sideRotationSpeed;
    [SerializeField] private float frontalRotationSpeed;
    [SerializeField] private float jumpSpeed;

    private bool sideRotationInput = false;
    private bool frontalRotationInput = false;
    private bool horizontalInput = false;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -horizontalSpeed * Time.deltaTime, 0); //Sin fuerzas, el avion deja de girar cuando se suelta el input
            horizontalInput = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, horizontalSpeed * Time.deltaTime, 0);
            horizontalInput = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -sideRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, sideRotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(frontalRotationSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-frontalRotationSpeed * Time.deltaTime, 0, 0);
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpSpeed);
        }
    }


    /*
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
            rb.AddTorque(new Vector3(0, -horizontalSpeed * Time.deltaTime, 0)); //Esto es con fuerzas. El avion sigue girando por mas que no haya input
        if (Input.GetKey(KeyCode.E))
            rb.AddTorque(new Vector3(0, horizontalSpeed * Time.deltaTime, 0));
        
        if (Input.GetKey(KeyCode.D))
            rb.AddTorque(new Vector3(0, 0, -sideRotationSpeed * Time.deltaTime)); 
        if (Input.GetKey(KeyCode.A))
            rb.AddTorque(new Vector3(0, 0, sideRotationSpeed * Time.deltaTime));
    }
    */
}
