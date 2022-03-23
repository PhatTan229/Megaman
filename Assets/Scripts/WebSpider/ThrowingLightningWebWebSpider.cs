using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingLightningWebWebSpider : StateMachineBehaviour
{
    private WebSpiderLightningWeb webPrefab;
    private Transform target;
    private Transform point;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (webPrefab == null) webPrefab = animator.GetComponent<WebSpider>().lightningWeb;
        if (target == null) target = animator.GetComponent<WebSpider>().target;
        if (point == null) point = animator.GetComponent<WebSpider>().lightningWebPoint;
        var web = Instantiate(webPrefab, point.position, point.rotation);
        web.target = target;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
