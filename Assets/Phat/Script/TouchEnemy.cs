using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEnemy : MonoBehaviour
{  
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<PlayerHP>(out var playerHP))
        {          
            playerHP.TakeDamage(damage);
        }
    }

    

}
