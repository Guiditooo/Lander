using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
            rb.AddTorque(new Vector3(0, -horizontalSpeed * Time.deltaTime, 0));
        else if (Input.GetKey(KeyCode.E))
            rb.AddTorque(new Vector3(0, horizontalSpeed * Time.deltaTime, 0));
    }

}
