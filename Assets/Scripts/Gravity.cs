using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Transform gravityCenter;
    [SerializeField] private float gravityForce;

    private Vector3 vectorUp;

    private void Start()
    {
        vectorUp = transform.position - gravityCenter.position;
    }

    private void LateUpdate()
    {
        vectorUp = transform.position - gravityCenter.position;
        //transform.up = vectorUp;
        transform.position -= vectorUp.normalized * gravityForce * Time.deltaTime; 
    }

    public Vector3 GetVectorForward() => transform.right;

}
