using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpider : MonoBehaviour
{
    public int contactDamage;
    public bool isAngry;
    public Transform electricStringPoint;
    public Transform lightningWebPoint;
    public Transform smallSpiderAttackPoint;
    public WebSpiderLightningWeb lightningWeb;
    public WebSpiderSmallSpider smallSpider;
    
    public LeafController treeBranch;
    public WebSpiderWebNetwork webNetwork;
    public Transform target;
    public static int currentWaypointIndex;
    public static Transform[] waypoints = new Transform[9];
    public static int RandomNumberFromArray(int[] numberArray)
    {
        var index = Random.Range(0, numberArray.Length);
        return numberArray[index];
    }
    public static int FindPathOnWeb(int currentPositionIndex)
    {
        switch (currentPositionIndex)
        {
            case (0):return RandomNumberFromArray(new int[] { 1, 3 });
            case (1): return RandomNumberFromArray(new int[] { 0, 2, 4 });
            case (2): return RandomNumberFromArray(new int[] { 1, 5 });
            case (3): return RandomNumberFromArray(new int[] { 0, 4, 6 });
            case (4): return RandomNumberFromArray(new int[] { 1, 3, 5, 7 });
            case (5): return RandomNumberFromArray(new int[] { 2, 4, 8 });
            case (6): return RandomNumberFromArray(new int[] { 3, 7 });
            case (7): return RandomNumberFromArray(new int[] { 4, 6, 8 });
            default: return RandomNumberFromArray(new int[] { 5, 7 });
        }
    }
}
