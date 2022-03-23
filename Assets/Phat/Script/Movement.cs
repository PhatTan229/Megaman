using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    [System.NonSerialized]public float Axist;
    public float speed;
    public float jumpForce;
    public Animator anim;
    public LayerMask ground;
    [SerializeField]private float checkRadius;
    public GameObject feet;
    [System.NonSerialized] public int facing;
    [System.NonSerialized] public bool onGround;
    [System.NonSerialized] public bool jumping;

    private void Awake()
    {
        facing = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        onGround = GroundCheck();
        jumping = !onGround; 
        FacingCheck();
        Move();              
        Jump();                   
        AnimationCheck();
    }

   
    private void Move()
    {
        Axist = Input.GetAxisRaw("Horizontal");
        var moveVelocity = rb.velocity;
        moveVelocity.x = Axist * speed;
        rb.velocity = moveVelocity;
        
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(feet.transform.position, checkRadius, ground) != null;
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            anim.SetTrigger("JumpState");
            var junpVelocity = rb.velocity;
            junpVelocity.y = jumpForce;
            rb.velocity = junpVelocity;
        }       
    }
    private void FacingCheck()
    {
        var characterFacing = transform.localScale;
        if(Axist < 0)
        {
            //transform.right = new Vector3(-1,0,0);
            facing = -1;
            characterFacing.x = -1;
        }
        else if(Axist > 0 )
        {
            //transform.right = new Vector3(1, 0, 0);
            facing = 1;
            characterFacing.x = 1;
        }
        else
        {
            //facing = 0; 
        }
        transform.localScale = characterFacing;
        
    }

    private void AnimationCheck()
    {
        if(Mathf.Abs(Axist) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("Running", true);
        }
        else if(Mathf.Abs(Axist) <= 0 && rb.velocity.y == 0)
        {
            anim.SetBool("Running", false);
        }
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("OnGround", onGround);
    }
}
