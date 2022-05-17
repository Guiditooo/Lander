using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    [SerializeField] private Transform gravityCenter;
    [SerializeField] private float gravityForce;

    private Vector3 vectorUp;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        vectorUp = transform.position - gravityCenter.position;
    }

    private void FixedUpdate()
    {
        vectorUp = transform.position - gravityCenter.position;
        rb.velocity = -vectorUp.normalized * gravityForce * Time.fixedDeltaTime;
    }

    private void LateUpdate()
    {
        //vectorUp = transform.position - gravityCenter.position;
        //transform.up = vectorUp;
        //rb.velocity = -vectorUp.normalized * gravityForce * Time.deltaTime;
        //rb.MovePosition(rb.position - vectorUp.normalized * gravityForce * Time.deltaTime);
        //transform.position -= vectorUp.normalized * gravityForce * Time.deltaTime; 
    }

    public Vector3 GetVectorForward() => transform.right;

}
