using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrashChecker : MonoBehaviour
{
    public static Action OnPlayerDeath;
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Choque con: " + col.name, col);
        if(col.tag == "Planet")
        OnPlayerDeath();

    }

}
