using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
    //public FailingLeaf[] leafCollection;
    public FailingLeaf leaf;
    public float leafFailingDelay;
    public float leafFailingRange;
    public IEnumerator MakeLeaf(Vector2 spiderPosition, int numberOfLeaf)
    {
        int i = 0;
        while (i < numberOfLeaf)
        {
            //var leafType = Random.Range(0, leafCollection.Length);
            var leafFailingX = Random.Range(-leafFailingRange, leafFailingRange);
            var failingPosition = new Vector2(spiderPosition.x + leafFailingX, spiderPosition.y);
            Instantiate(leaf, failingPosition, Quaternion.identity);
            yield return new WaitForSeconds(leafFailingDelay);
            i++;
        }
    }
    public void CreateLeaf(Vector2 spiderPosition, int numberOfLeaf)
    {
        StartCoroutine(MakeLeaf(spiderPosition, numberOfLeaf));
    }
}
