using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMettaurD2 : StateMachineBehaviour
{
    public int speed;
    public float wallDetectingRange;
    public float playerDetectingRange;
    public float dangerDetectingRange;
    public float shootingDelay;
    public float hidingDelay;

    private Rigidbody2D rigid;
    private Transform gapDetector;
    
    private float nextShootingTime;
    private float nextHidingTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //speed *= -1;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        if (gapDetector == null) gapDetector = animator.GetComponent<MettaurD2>().gapDetector;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var newVelocity = rigid.velocity;
        newVelocity.x = -speed * animator.transform.right.x;
        rigid.velocity = newVelocity;
        if (Physics2D.Raycast(animator.transform.position, -animator.transform.right, wallDetectingRange, LayerMask.GetMask("Ground")))
        {
            animator.transform.right *= -1;
            //var yAngle = speed > 0 ? 0 : 180;
            
            
            //animator.transform.rotation = Quaternion.Euler(0, yAngle, 0);
            //speed *= -1;
            //xForce *= -1;
        }
        var gapDetectingDirection = gapDetector.position - animator.transform.position;
        if (!Physics2D.Raycast(animator.transform.position, gapDetectingDirection, gapDetectingDirection.magnitude, LayerMask.GetMask("Ground")))
        {
            animator.SetTrigger("Jump");
            return;
        }
        if (Physics2D.Raycast(animator.transform.position, -animator.transform.right, playerDetectingRange, LayerMask.GetMask("Player")) && Time.time > nextShootingTime)
        {
            animator.SetTrigger("Shoot");
            nextShootingTime = Time.time + shootingDelay;
            return;
        }

        if (Physics2D.Raycast(animator.transform.position, -animator.transform.right, dangerDetectingRange, LayerMask.GetMask("PlayerProjectile")) && Time.time > nextHidingTime)
        {
            animator.SetTrigger("StartHiding");
            nextHidingTime = Time.time + hidingDelay;
            //return;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
