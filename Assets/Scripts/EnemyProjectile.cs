using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int speed;
    public int damage;
    public Vector2 direction;

    private Vector3 normalDirection;
    private void Start()
    {
        normalDirection = direction.normalized;
        normalDirection.z = 0;
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * normalDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out var playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
