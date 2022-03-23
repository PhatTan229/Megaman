using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSliding : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private WallMove wallMove;
    private VFXList x_vfx;
    private GameObject slidingDust;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        x_vfx = animator.GetComponent<VFXList>();
        wallMove = animator.GetComponent<WallMove>();
        rb = animator.GetComponent<Rigidbody2D>();

        var slidingVFX = x_vfx.vfxPrefab[5];
        slidingDust = VFXPlayer.PlayAnimation(slidingVFX, wallMove.slidingDustSpawnPosition, slidingVFX.transform.rotation);
        slidingDust.transform.SetParent(GameObject.Find("Player").transform);
        slidingDust.transform.localScale = new Vector3(1, 1, 1);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var slidingSpeed = rb.velocity;
        slidingSpeed.y = -wallMove.SLIDING_SPEED;
        rb.velocity = slidingSpeed;
        Debug.Log("Sliding Wall");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(slidingDust);
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
