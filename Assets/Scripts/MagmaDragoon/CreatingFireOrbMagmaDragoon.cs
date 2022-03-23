using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingFireOrbMagmaDragoon : StateMachineBehaviour
{
    private MagmaDragoonFireOrb fireOrbPrefab;
    private Transform creatingPosition;
    private MagmaDragoonFireOrb createdFireOrb;
    private Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fireOrbPrefab == null) fireOrbPrefab = animator.GetComponent<MagmaDragoon>().fireOrb;
        if (creatingPosition == null) creatingPosition = animator.GetComponent<MagmaDragoon>().firePillarPoint;
        if (target == null) target = animator.GetComponent<MagmaDragoon>().target;
        createdFireOrb = Instantiate(fireOrbPrefab, creatingPosition.position, Quaternion.identity);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = (target.position - createdFireOrb.transform.position).normalized;
        createdFireOrb.normalDirection = direction;

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
