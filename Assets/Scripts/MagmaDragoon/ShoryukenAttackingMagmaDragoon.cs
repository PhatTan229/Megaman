using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoryukenAttackingMagmaDragoon : StateMachineBehaviour
{
    public float xForce;
    public float yForce;
    private Rigidbody2D rigid;
    private MagmaDragoon dragoon;
    private TouchEnemy contact;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (contact == null) contact = animator.GetComponent<TouchEnemy>();
        contact.damage = 8;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(-xForce * animator.transform.right.x, yForce));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var isMovingUp = rigid.velocity.y > 0;
        if (!isMovingUp) animator.SetTrigger("Fail");
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        contact.damage = 4;
    }

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
