using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulltet : MonoBehaviour
{
    public int damge;
    public float speed;
    private int bulletDirection;
    public Animator anim;
    public AnimationClip hitClip;
    public AnimationClip nonPenClip;
    private float destroyTime;
    //public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameObject.Find("Player").GetComponent<WallMove>().slidingWall)
        {
            bulletDirection = -GameObject.Find("Player").GetComponent<Movement>().facing;
            transform.localScale = -BulletFacing();
        }
        else
        {
            bulletDirection = GameObject.Find("Player").GetComponent<Movement>().facing;
            transform.localScale = BulletFacing();
        }       
    }

    private Vector3 BulletFacing()
    {
        var bulletFacing = transform.localScale;
        if (GameObject.Find("Player").GetComponent<Movement>().facing < 0)
        {
            bulletFacing.x = -1;
        }
        if (GameObject.Find("Player").GetComponent<Movement>().facing > 0)
        {
            bulletFacing.x = 1;
        }
        return  bulletFacing;       
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(speed * Time.deltaTime * bulletDirection, 0, 0);
        //transform.Translate(speed * direction.normalized * Time.deltaTime);
    }    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHp>(out var enemyHealth))
        {          
            if(!enemyHealth.invisible)
            {
                anim.SetTrigger("Hit");
                enemyHealth.TakeDamage(damge);
                destroyTime = hitClip.length;
            }
            else
            {
                anim.SetTrigger("NonPen");
                destroyTime = nonPenClip.length;
            }
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            anim.SetTrigger("Hit");
            destroyTime = hitClip.length;
        }
        enabled = false;
        Destroy(gameObject, destroyTime);
    }
}
