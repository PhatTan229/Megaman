using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailingLeaf : MonoBehaviour
{
    public float leafGravity;
    public Rigidbody2D rigid;
    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        rigid.gravityScale = leafGravity;
    }

}
