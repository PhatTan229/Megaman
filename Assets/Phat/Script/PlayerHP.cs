using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HP
{
    [System.NonSerialized]public bool invisible = false;
    public float invinsibleTime;
    public Rigidbody2D rb;    
   
    private void OnValidDate()
    {
        anim = GetComponent<Animator>();
    }   
    public override void TakeDamage(int damge)
    {
        if (invisible == false && Hp > 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            invisible = true;          
            anim.SetBool("GetHit", true);
            anim.SetBool("Blinking", true);           
            Invoke(nameof(StopInvisible), invinsibleTime);                             
            Invoke(nameof(StopGetHitAnimation), 0.5f);
            StartCoroutine(EnableLayerCollision());
            base.TakeDamage(damge);
        }      
    }
    private IEnumerator EnableLayerCollision()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        yield return new WaitForSeconds(invinsibleTime);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }

    private void StopGetHitAnimation()
    {
        anim.SetBool("GetHit", false);
    }
    private void StopInvisible()
    {
        anim.SetBool("Blinking", false);
        invisible = false;
    }

    public override void Die()
    {
        base.Die();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
    }   
}
