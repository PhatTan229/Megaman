using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingWebNetworkWebSpider : StateMachineBehaviour
{
    private WebSpiderWebNetwork networkPrefab;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (networkPrefab == null) networkPrefab = animator.GetComponent<WebSpider>().webNetwork;
        var network = Instantiate(networkPrefab, animator.transform.position, Quaternion.identity);
        for (int i = 0; i < 9; i++)
        {
            WebSpider.waypoints[i] = network.waypoints[i].transform;
        }
        WebSpider.currentWaypointIndex = 4;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<ElectricString>().enabled = false;
        animator.GetComponent<LineRenderer>().enabled = false;
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
