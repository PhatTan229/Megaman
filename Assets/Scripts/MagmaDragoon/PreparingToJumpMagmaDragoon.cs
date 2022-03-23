using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingToJumpMagmaDragoon : StateMachineBehaviour
{
    
    public float yForce;
    private float xForce;
    private Transform hero;
    private Rigidbody2D rigid;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hero == null) hero = animator.GetComponent<MagmaDragoon>().target;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        xForce = ProjectileMotion.GetFxFromFy(yForce, hero.position.x - animator.transform.position.x);
        rigid.AddForce(new Vector2(xForce, yForce));
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
