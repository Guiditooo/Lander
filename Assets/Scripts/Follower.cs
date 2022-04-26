using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        transform.LookAt(target);
    }

}
