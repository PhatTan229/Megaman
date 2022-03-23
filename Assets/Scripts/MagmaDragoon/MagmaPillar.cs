using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaPillar : MonoBehaviour
{
    public int damage;
    public float speed;
    public float maxHeight;
    public bool isCreatedByBoss;
    private float minY;
    private float maxY;
    private Vector2 target;
    void Start()
    {
        //currentDirection = new Vector2(0, speed * Time.deltaTime);
        minY = transform.position.y;
        maxY = minY + maxHeight;
        target = new Vector2(transform.position.x, maxY);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.y == maxY) target.y = minY;
        if (transform.position.y == minY)
        {
            if (isCreatedByBoss) Destroy(gameObject);
            else target.y = maxY;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HP>(out var hp))
        {
            if (!hp.isImmuneToFire) hp.TakeDamage(damage);
        }
    }
}
