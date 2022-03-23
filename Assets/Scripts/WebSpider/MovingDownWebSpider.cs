using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDownWebSpider : StateMachineBehaviour
{
    public float speed;
    public float minDistance;
    public float maxDistance;
    private float distance;
    private Vector2 destination;
    private WebSpider spider;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spider == null) spider = animator.GetComponent<WebSpider>();
        destination = animator.transform.position;
        if (spider.isAngry) distance = 7f;
        else distance = Random.Range(minDistance, maxDistance);
        
        destination.y -= distance;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);
        if ((Vector2)animator.transform.position == destination) animator.SetTrigger("FindPlayer");
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
