using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromObject;

    private void Update()
    {
        transform.LookAt(target);
        Vector3 auxPos = target.position - transform.position;
        auxPos.Normalize();
        auxPos *= 1/distanceFromObject;
        transform.position = auxPos;
    }

}
