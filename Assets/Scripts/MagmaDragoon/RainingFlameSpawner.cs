using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingFlameSpawner : MonoBehaviour
{
    public Color pointColor = Color.white;
    public float radius;
    public float space;
    public EnemyProjectile rainingFlame;
    private void OnDrawGizmos()
    {
        Gizmos.color = pointColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
    public void CreateRainingFlames(int numberOfFlame)
    {
        var direction = space * rainingFlame.direction.normalized;
        var startPosition = (Vector2)transform.position;
        for (int i = 0; i < numberOfFlame; i++)
        {
            startPosition = startPosition - direction;
            Instantiate(rainingFlame, startPosition, transform.rotation);
        }
        
    }

}
