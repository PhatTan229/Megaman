using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTreeWebSpider : StateMachineBehaviour
{
    public int numberOfLeaf;

    private WebSpider spider;
    private LeafController treeBranch;
    private CapsuleCollider2D collider;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (collider == null) collider = animator.GetComponent<CapsuleCollider2D>();
        if (treeBranch == null) treeBranch = animator.GetComponent<WebSpider>().treeBranch;
        if (spider == null) spider = animator.GetComponent<WebSpider>();

        collider.enabled = false;

        if (spider.isAngry)
        {
            animator.transform.position = treeBranch.transform.position;
            animator.SetBool("SecondPhase", true);
        }
        else
        {
            var offset = Random.Range(-7f, 7f);
            var newPosition = animator.transform.position;
            newPosition.x = treeBranch.transform.position.x + offset;
            animator.transform.position = newPosition;
        }

        treeBranch.CreateLeaf(animator.transform.position, numberOfLeaf);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        collider.enabled = true;
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
