using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaDragoonFireOrb : MonoBehaviour
{
    public int speed;
    public int damage;
    public Vector2 normalDirection;
    public MagmaRipple ripple;
    public Transform top;



    void Update()
    {
        transform.Translate(speed * Time.deltaTime * normalDirection);
        var isInsideMagma = Physics2D.OverlapCircle(top.position, 0.1f, LayerMask.GetMask("Magma")) != null;
        if (isInsideMagma)
        {
            CreateMagmaRipple();
            Destroy(gameObject);
        }
    }

    
    private void CreateMagmaRipple()
    {
        Instantiate(ripple, top.position, top.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out var playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
    //private void CreateMagmaPillar()
    //{
    //    Instantiate(magmaPillar, transform.position, transform.rotation);
    //}
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}
