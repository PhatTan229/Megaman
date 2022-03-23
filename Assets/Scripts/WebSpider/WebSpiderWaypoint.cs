using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderWaypoint : MonoBehaviour
{
    public Color pointColor = Color.white;
    public float radius;
    private void OnDrawGizmos()
    {
        Gizmos.color = pointColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
