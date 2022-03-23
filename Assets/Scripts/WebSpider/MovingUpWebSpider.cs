using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpWebSpider : StateMachineBehaviour
{
    public float speed;
    private LeafController treeBranch;
    private Vector2 destination;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (treeBranch == null) treeBranch = animator.GetComponent<WebSpider>().treeBranch;
        destination = new Vector2(animator.transform.position.x, treeBranch.transform.position.y);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);
        var isOnTree = (Vector2)animator.transform.position == destination;
        if (isOnTree)
        {
            animator.SetTrigger("IsOnTree");
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
