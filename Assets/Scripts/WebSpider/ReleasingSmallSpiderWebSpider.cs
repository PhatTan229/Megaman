using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasingSmallSpiderWebSpider : StateMachineBehaviour
{
    public int xForce1;
    public int yForce1;
    public int xForce2;
    public int yForce2;
    private WebSpiderSmallSpider smallSpider;
    private Transform smallSpiderSpawner;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (smallSpider == null) smallSpider = animator.GetComponent<WebSpider>().smallSpider;
        if (smallSpiderSpawner == null) smallSpiderSpawner = animator.GetComponent<WebSpider>().smallSpiderAttackPoint;

        var baby1 = Instantiate(smallSpider, smallSpiderSpawner.position, Quaternion.Euler(0, 0, 0));
        baby1.Jump(-xForce1, yForce1);
        var baby2 = Instantiate(smallSpider, smallSpiderSpawner.position, Quaternion.Euler(0, 0, 0));
        baby2.Jump(-xForce2, yForce2);
        var baby3 = Instantiate(smallSpider, smallSpiderSpawner.position, Quaternion.Euler(0, 180, 0));
        baby3.Jump(xForce1, yForce1);
        var baby4 = Instantiate(smallSpider, smallSpiderSpawner.position, Quaternion.Euler(0, 180, 0));
        baby4.Jump(xForce2, yForce2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
