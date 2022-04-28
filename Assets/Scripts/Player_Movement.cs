using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float sideRotationSpeed;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
            rb.AddTorque(new Vector3(0, -horizontalSpeed * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.E))
            rb.AddTorque(new Vector3(0, horizontalSpeed * Time.deltaTime, 0));
        /*
        if (Input.GetKey(KeyCode.D))
            rb.AddTorque(new Vector3(0, 0, -sideRotationSpeed * Time.deltaTime)); 
        if (Input.GetKey(KeyCode.A))
            rb.AddTorque(new Vector3(0, 0, sideRotationSpeed * Time.deltaTime));
        */
    }

}
