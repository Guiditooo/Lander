using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nest : MonoBehaviour
{
    public static Action OnDiscoverNest;

    public int id { get; private set; } = 0;

    [SerializeField] private bool discovered;

    private static int nestCount = 0;
    private static int maxNestCount = 0;
    public static int GetNestCount() => nestCount;
    public static int GetMaxNestCount() => maxNestCount;

    private void Awake()
    {
        id++;
        maxNestCount++;
        discovered = false;
    }

    public void DiscoverNest()
    {
        if (discovered) return;
        Debug.Log("Discovered " + name, gameObject);
        nestCount++;
        discovered = true;
        OnDiscoverNest();
    }

}
