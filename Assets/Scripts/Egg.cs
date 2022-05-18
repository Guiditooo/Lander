using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private static int eggCount = 0;
    private static int maxEggCount = 0;
    public static int GetEggCount() => eggCount;
    public static int GetMaxEggCount() => maxEggCount;

    private void Awake()
    {
        eggCount++;
        maxEggCount = eggCount;
    }

    public void GrabEgg()
    {
        eggCount--;
        Debug.Log("Webo agarrado");
        Destroy(this.gameObject);
    }

}
