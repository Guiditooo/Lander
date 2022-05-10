using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Checker : MonoBehaviour
{
    private bool baseChecked = false;
    public bool IsChecked() => baseChecked;

    [SerializeField] private MeshRenderer mr;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ship"))
        {
            baseChecked = true;
            ChangeColorBeforeTrigger();
        }
    }

    private void ChangeColorBeforeTrigger()
    {
        mr.material.color = Color.green;
    }

}
