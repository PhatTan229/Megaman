using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOnWebWebSpider : StateMachineBehaviour
{
    public int speed;
    private Vector2 destination;
    private int destinationIndex;
    private int numberOfDestination;
    private int numberOfCompletedDestination;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        destinationIndex = WebSpider.FindPathOnWeb(WebSpider.currentWaypointIndex);
        destination = WebSpider.waypoints[destinationIndex].position;
        numberOfDestination = Random.Range(3, 6);
        numberOfCompletedDestination = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);
        if ((Vector2)animator.transform.position == destination)
        {
            numberOfCompletedDestination++;
            WebSpider.currentWaypointIndex = destinationIndex;
            if (numberOfCompletedDestination < numberOfDestination)
            {

                destinationIndex = WebSpider.FindPathOnWeb(WebSpider.currentWaypointIndex);
                destination = WebSpider.waypoints[destinationIndex].position;
            }
            else
            {
                var choice = Random.Range(0, 2);
                if (choice == 0) animator.SetTrigger("LightningWeb");
                if (choice == 1) animator.SetTrigger("SmallSpiderAttack");
            } 
        }
    }

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
