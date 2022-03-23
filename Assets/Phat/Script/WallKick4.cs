using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKick4 : StateMachineBehaviour
{
    private Movement move;
    private VFXList x_vfx;
    private WallMove wallMove;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wallMove = animator.GetComponent<WallMove>();
        x_vfx = animator.GetComponent<VFXList>();
        move = animator.GetComponent<Movement>();
        var sparkVFX = x_vfx.vfxPrefab[4];
        var sparkClip = x_vfx.vfxClip[4];
        var g = VFXPlayer.PlayAnimation(sparkVFX, wallMove.sparkSpawnPosition, sparkVFX.transform.rotation);
        Destroy(g, sparkClip.length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        move.rb.velocity = new Vector2(-move.Axist * wallMove.wallJumpFroce, move.jumpForce + 2);           
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
