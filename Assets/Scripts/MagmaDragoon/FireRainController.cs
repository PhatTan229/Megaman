using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRainController : MonoBehaviour
{
    public RainingFlameSpawner[] spawners;

    public void CreateFireRain()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            var numberOfFlame = Random.Range(3, 5);
            spawners[i].CreateRainingFlames(numberOfFlame);
        }
    }
}
