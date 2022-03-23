using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderWebNetwork : MonoBehaviour
{
    public WebSpiderGiantWeb webPrefab;
    public WebSpiderWaypoint[] waypoints;
    public int speed;
    public float offset;
    private WebSpiderGiantWeb[] webs = new WebSpiderGiantWeb[4];
    private Vector2[] directions = new Vector2[4];
    void Start()
    {
        directions[0] = new Vector2(offset, 0);
        directions[1] = new Vector2(-offset, 0);
        directions[2] = new Vector2(0, offset);
        directions[3] = new Vector2(0, -offset);
        for (int i = 0; i < 4; i++)
        {
            webs[i] = Instantiate(webPrefab, transform.position, Quaternion.identity);
            webs[i].destination = (Vector2)transform.position + directions[i];
            webs[i].speed = speed;
        }
    }

}
