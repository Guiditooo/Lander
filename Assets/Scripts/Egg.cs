using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Egg : MonoBehaviour
{

    public static Action OnEggPickUp;

    private static int eggCount = 0;
    private static int maxEggCount = 0;
    public int id { get; private set; }
    public static int GetEggCount() => eggCount;
    public static int GetMaxEggCount() => maxEggCount;

    private void Awake()
    {
        id++;
        maxEggCount++;
    }

    public void GrabEgg()
    {
        eggCount++;
        Debug.Log("Webo agarrado");
        OnEggPickUp();
        Destroy(this.gameObject);
    }

}
