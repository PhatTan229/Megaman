using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private Movement move;
    public LayerMask ground;
    [System.NonSerialized] public bool inWall;
    public float SLIDING_SPEED;
    [SerializeField] private float wallCheckRadius;
    public bool slidingWall;
    public PhysicsMaterial2D fric;
    public float wallJumpFroce;
    private float initialSpeed;
    public float wallJumpAddSpeed;
    public GameObject wallCheck;
    public GameObject sparkSpawn;
    [System.NonSerialized] public Vector3 sparkSpawnPosition;
    public GameObject slidingDustSpawn;
    [System.NonSerialized] public Vector3 slidingDustSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        initialSpeed = move.speed;
    }
    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            move.speed = initialSpeed;
        }
    }
    void Update()
    {
        slidingDustSpawnPosition = slidingDustSpawn.transform.position;
        sparkSpawnPosition = sparkSpawn.transform.position;
        inWall = InWall();
        slidingWall = (move.Axist >= 1 || move.Axist <= -1) && (move.onGround == false && inWall == true);
        //WallSliding();
        AnimationCheck();
        if(slidingWall == false)
        {
            fric.friction = 0;
        }
        else
        {
            fric.friction = 0.4f;
        }
        WallJump();
    }

    private bool InWall()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position, wallCheckRadius, ground) != null;
    }

    //private void WallSliding()
    //{
    //    if (slidingWall)
    //    {
    //        var slidingSpeed = move.rb.velocity;
    //        slidingSpeed.y = -SLIDING_SPEED;
    //        move.rb.velocity = slidingSpeed;
    //    }       
    //}

    private void WallJump()
    {
        move.anim.SetBool("WallJump", false);
        if (inWall && !move.onGround && Input.GetKeyDown(KeyCode.Space))
        {

            if (Input.GetKey(KeyCode.X))
            {
                
                move.speed += wallJumpAddSpeed;
                //var wallJump = move.rb.velocity;
                //wallJump = new Vector2(-move.Axist * wallJumpFroce + 5, move.jumpForce + 2);
                //move.rb.velocity = wallJump;
            }
            else
            {
                
                
            }

            move.anim.SetBool("WallJump", true);
        }
    }
    
    private void AnimationCheck()
    {
        move.anim.SetBool("InWall", slidingWall);       
    }
}
