using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MettaurD2State
{
    walking, jumping, shooting, opening, closing
}

public class MettaurD2 : MonoBehaviour
{
    //public int contactDamage;
    //public int speed;
    //public float playerDetectingRange;
    //public float wallDetectingRange;

    //public float shootingDuration;
    //public Transform gapDetector;
    public Rigidbody2D rigid;
    public Animator anim;
    public Transform mouth;
    public Transform foot;
    public Transform gapDetector;
    public EnemyProjectile projectile;

    //private MettaurD2State currentState;
    private void OnValidate()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //private void Jump()
    //{
    //    rigid.AddForce(new Vector2(xForce, yForce));
    //}
    private void ShootSomething()
    {
        
        

        //nextShootTime = Time.time + shootingDelay;
        //Invoke("StopShooting", shootingDuration);
    }
    public void Shoot()
    {
        var yAngle = 180 - transform.rotation.eulerAngles.y;
        var newQuaternion = Quaternion.Euler(0, yAngle, 0);
        Instantiate(projectile, mouth.position, newQuaternion);
    }
    public void StopHiding()
    {
        anim.SetTrigger("StopHiding");
    }


    //public int contactDamage;
    //public int speed;
    //public int xForce;
    //public int yForce;
    //public float playerDetectingRange;
    //public float wallDetectingRange;
    //public float shootingDelay;
    //public float shootingDuration;
    //public Transform gapDetector;
    //public Rigidbody2D rigid;
    //public Animator anim;
    //public Transform mouth;
    //public Transform foot;
    //public MettaurD2Projectile projectile;
    //private MettaurD2State currentState;
    //private float nextShootTime;

    //private void Start()
    //{
    //    currentState = MettaurD2State.walking;
    //    speed *= -1;
    //    xForce *= -1;
    //}
    //private void Update()
    //{

    //    var isOnGround = Physics2D.OverlapCircle(foot.position, 0.1f, LayerMask.GetMask("Ground")) != null;
    //    if (!isOnGround) currentState = MettaurD2State.jumping;
    //    else if (currentState != MettaurD2State.shooting) currentState = MettaurD2State.walking;


    //    if (currentState == MettaurD2State.walking)
    //    {
    //        if (Physics2D.Raycast(transform.position, -transform.right, playerDetectingRange, LayerMask.GetMask("Player")) && Time.time > nextShootTime) 
    //            Shoot();
    //        else Move();

    //    }

    //    if (currentState == MettaurD2State.jumping)
    //    {
    //        anim.SetBool("IsMovingUp", rigid.velocity.y > 0);
    //    }
    //    anim.SetBool("IsOnGround", isOnGround);
    //}

    //private void Move()
    //{
    //    var gapDetectingDirection = gapDetector.position - transform.position;
    //    if (Physics2D.Raycast(transform.position, gapDetectingDirection, gapDetectingDirection.magnitude, LayerMask.GetMask("Ground")))
    //        Walk();
    //    else Jump();
    //}
    //private void Jump()
    //{

    //    anim.SetTrigger("Jump");
    //    rigid.AddForce(new Vector2(xForce, yForce));
    //}
    //private void Walk()
    //{
    //    if (Physics2D.Raycast(transform.position, -transform.right, wallDetectingRange, LayerMask.GetMask("Ground")))
    //    {
    //        var yAngle = speed > 0 ? 0 : 180;
    //        transform.rotation = Quaternion.Euler(0, yAngle, 0);
    //        speed *= -1;
    //        xForce *= -1;
    //    }

    //    var newVelocity = rigid.velocity;
    //    newVelocity.x = speed;
    //    rigid.velocity = newVelocity;
    //}
    //private void Shoot()
    //{
    //    anim.SetTrigger("Shoot");
    //    currentState = MettaurD2State.shooting;

    //    nextShootTime = Time.time + shootingDelay;
    //    Invoke(nameof(StopShooting), shootingDuration);
    //}
    //public void ShootBullet()
    //{
    //    var yAngle = 180 - transform.rotation.eulerAngles.y;
    //    var newQuaternion = Quaternion.Euler(0, yAngle, 0);
    //    Instantiate(projectile, mouth.position, newQuaternion);
    //}
    //private void StopShooting()
    //{
    //    currentState = MettaurD2State.walking;
    //}
    //private void UpdateFacing()
    //{
    //    var xVelocity = rigid.velocity.x;
    //    if (xVelocity != 0)
    //    {
    //        Debug.Log("not zero");
    //        var yAngle = xVelocity < 0 ? 0 : 180;
    //        transform.rotation = Quaternion.Euler(0, yAngle, 0);
    //    }
    //}
    //private void UpdateAnimation()
    //{

    //}
}
