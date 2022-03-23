using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Movement move;
    public float dashSpeed;
    public bool isDashing =  false;
    public float dashTime;
    public float addSpeed;
    private float initialSpeed;
    public float dashJumpSpeed;
    public GameObject dashBoost;
    [System.NonSerialized] public Vector3 dashBoostPosition;
    private VFXList x_vfx;
    private GameObject dashVFX;
    private GameObject startDust;
    public GameObject dust;
    private Vector3 dustPosition;
    //public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        x_vfx = GetComponent<VFXList>();
        move = GetComponent<Movement>();
        initialSpeed = move.speed;
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground") && isDashing)
        {
            StopDash();           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
             move.speed = initialSpeed;
        }
    }
        // Update is called once per frame
        void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X) && move.onGround    )
        //{
        //    if(isDashing == false)
        //    {
        //        StartCoroutine(Dashing());
        //    }
        //}
        dashBoostPosition = dashBoost.transform.position;
        dustPosition = dust.transform.position; 
        DashJump();
        Dashing();
        AnimationCheck();
        
        //Debug.Log(move.rb.velocity);
    } 
    
    //private IEnumerator Dashing()
    //{
    //    move.anim.SetTrigger("DashState");
    //    var dashVelocity = move.rb.velocity;
    //    dashVelocity.x = dashSpeed * move.facing;
    //    move.rb.velocity = dashVelocity;
    //    move.enabled = false;
    //    isDashing = true;
        
    //    yield return new WaitForSeconds(dashTime);

    //    StopDash();
    //}

    private void Dashing()
    {              
        if (Input.GetKeyDown(KeyCode.X) && move.onGround && move.Axist != 0)
        {
            isDashing = true;
            move.anim.SetTrigger("DashState");
            //var dashVelocity = move.rb.velocity;
            //dashVelocity.x = dashSpeed * move.facing;
            //move.rb.velocity = dashVelocity;
            //move.enabled = false;         
            //dashTime -= Time.deltaTime;
            var dashVFXPrefab = x_vfx.vfxPrefab[3];
            var dashVFXClip = x_vfx.vfxClip[3];
            dashVFX = VFXPlayer.PlayAnimation(dashVFXPrefab,dashBoostPosition, dashVFXPrefab.transform.rotation);
            dashVFX.transform.SetParent(GameObject.Find("Player").transform);
            dashVFX.transform.localScale = new Vector3(1, 1, 1);

            var starDustPrefab = x_vfx.vfxPrefab[8];
            var startDustClip = x_vfx.vfxClip[8];
            startDust = VFXPlayer.PlayAnimation(starDustPrefab, dustPosition, starDustPrefab.transform.rotation);
            startDust.transform.localScale = new Vector3(move.facing, 1, 1);
            Destroy(startDust, startDustClip.length);
            Invoke(nameof(StopDash), dashTime);
        }      
    }

    public void StopDash()
    {
        Destroy(dashVFX);
        move.rb.velocity = Vector2.zero;
        dashTime = 0.5f;
        //cooldown = 1;
        isDashing = false;
        move.enabled = true;
    }

    private void DashJump()
    {
        if(move.onGround && isDashing && Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke(nameof(StopDash));
            StopDash();

            if (move.facing < 0 || move.facing > 0)
            {
                move.rb.velocity = new Vector2(0, move.jumpForce);
                move.speed += addSpeed;
            }
        }
    }   

    private void AnimationCheck()
    {
        move.anim.SetBool("Dashing",isDashing);
    }
}
