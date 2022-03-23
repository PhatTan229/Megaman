using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingMettaurD2 : StateMachineBehaviour
{
    public float hidingDuration;
    private MettaurD2 root;
    private EnemyHp hp;
    //private float startHidingTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hp == null) hp = animator.GetComponent<EnemyHp>();
        hp.invisible = true;
        if (root == null) root = animator.GetComponent<MettaurD2>();
        root.Invoke(nameof(root.StopHiding), hidingDuration);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (Time.time - startHidingTime > hidingDuration) animator.SetTrigger("StopHiding");
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hp.invisible = false;
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
