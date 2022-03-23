using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderWalkingSmallSpider : StateMachineBehaviour
{
    public float offset;
    public int speed;
    private Transform head;
    private Rigidbody2D rigid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        if (head == null) head = animator.GetComponent<WebSpiderSmallSpider>().head;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //var newVelocity = rigid.velocity;
        //newVelocity.x = -speed * animator.transform.right.x;


        rigid.velocity = -speed * animator.transform.right;

        var isOnWall = Physics2D.OverlapCircle(head.position, 0.1f, LayerMask.GetMask("Ground")) != null;
        if (isOnWall)
        {
            var newPosition = animator.transform.position;
            newPosition.x -= offset * animator.transform.right.x;
            animator.transform.position = newPosition;


            var yAngle = animator.transform.rotation.eulerAngles.y;
            animator.transform.rotation = Quaternion.Euler(0, yAngle, -90);
            
        }
        //if (isOnWall) animator.SetTrigger("IsOnWall");


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
