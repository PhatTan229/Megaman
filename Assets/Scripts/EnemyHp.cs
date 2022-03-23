using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : HP
{
    public bool invisible = false;
    public float invisibleTime;
    public Rigidbody2D rb;
    public override void TakeDamage(int damge)
    {
        base.TakeDamage(damge);
        if (isBoss && !invisible)
        {
            invisible = true;
            anim.SetBool("Blinking", true);
            Invoke(nameof(StopInvisible), invisibleTime);
        }   
    }

    private void StopInvisible()
    {
        invisible = false;
        anim.SetBool("Blinking", false);
    }
    public override void Die()
    {
        base.Die();
        rb.velocity = Vector2.zero;
        
        if (isBoss)
        {
            StartCoroutine(SlowMotion());
        }      
    }

    private IEnumerator SlowMotion()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }
}
