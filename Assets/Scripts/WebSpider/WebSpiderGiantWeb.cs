using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderGiantWeb : MonoBehaviour
{
    public int speed;
    public Vector2 destination;
    private IEnumerator StopMoving()
    {
        yield return new WaitUntil(() => (Vector2)transform.position == destination);
        enabled = false;
    }
    void Start()
    {
        StartCoroutine(StopMoving());
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
