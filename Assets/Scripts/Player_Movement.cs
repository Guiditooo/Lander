using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float sideRotationSpeed;
    [SerializeField] private float frontalRotationSpeed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private float correctionThreshold = 1;
    [SerializeField] private float correctionSpeed = 2;

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
        if (sideRotationInput) sideRotationInput = false;
        if (frontalRotationInput) frontalRotationInput = false;
        if (horizontalInput) horizontalInput = false;

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
            sideRotationInput = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, sideRotationSpeed * Time.deltaTime);
            sideRotationInput = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(frontalRotationSpeed * Time.deltaTime, 0, 0);
            frontalRotationInput = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-frontalRotationSpeed * Time.deltaTime, 0, 0);
            frontalRotationInput = true;
        }


        if (!horizontalInput)
        {
            float auxCondition = Vector3.Angle(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z), new Vector3(transform.forward.x, 0, transform.forward.z));

            if (auxCondition > correctionThreshold)
            {
                Vector3 camAngle = Camera.main.transform.eulerAngles;

                camAngle.y -= transform.rotation.eulerAngles.y;
             
                if ((camAngle.y > -180 && camAngle.y < 0) || (camAngle.y > 180)) //LEFT CORRECTION
                {
                    transform.Rotate(Vector3.up * -correctionSpeed * Time.deltaTime);
                }
                else                                                             //RIGHT CORRECTION
                {
                    transform.Rotate(Vector3.up * correctionSpeed * Time.deltaTime);
                }
            }
        }

        if (!sideRotationInput)
        {
            if (transform.eulerAngles.z > correctionThreshold && transform.eulerAngles.z < 360 - correctionThreshold)
            {
                Debug.Log(transform.eulerAngles.z);
                if (transform.eulerAngles.z < 180) //LEFT CORRECTION
                {
                    transform.Rotate(Vector3.forward * -correctionSpeed * Time.deltaTime);
                }
                else                               //RIGHT CORRECTION
                {
                    transform.Rotate(Vector3.forward * correctionSpeed * Time.deltaTime);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpSpeed);
        }
    }

}
