using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingMagmaDragoon : StateMachineBehaviour
{
    //public float speed;
    public float force;
    private Transform hero;
    private Transform foot;
    private Rigidbody2D rigid;
    private Vector2 kickingDirection;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hero == null) hero = animator.GetComponent<MagmaDragoon>().target;
        if (foot == null) foot = animator.GetComponent<MagmaDragoon>().foot;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        kickingDirection = (hero.position - animator.transform.position).normalized * force;
        rigid.AddForce(kickingDirection);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.Translate(speed * Time.deltaTime * kickingDirection.normalized);
        var isOnGround = Physics2D.OverlapCircle(foot.position, 0.1f, LayerMask.GetMask("Ground")) != null;
        if (isOnGround)
        {
            animator.SetTrigger("Land");
            rigid.velocity = Vector2.zero;
        }
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
