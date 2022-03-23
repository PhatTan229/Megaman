using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMagmaDragoon : StateMachineBehaviour
{
    public float closeCombatRange;
    private Transform hero;
    private bool isTriggering;
    private Rigidbody2D rigid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        if (hero == null) hero = animator.GetComponent<MagmaDragoon>().target;
        //isTriggering = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (hero == null) return;
        var xDirection = animator.transform.position.x > hero.position.x ? 1 : -1;
        animator.transform.right = new Vector3(xDirection, 0, 0);
       
        //if (isTriggering) return;
        
        if (Physics2D.Raycast(animator.transform.position, -animator.transform.right, closeCombatRange, LayerMask.GetMask("Player")))
        {
            animator.SetTrigger("Shoryuken");
            
            //Debug.Log($"Shoryuken {Time.frameCount}");
        }
        else
        {
            var choice = Random.Range(1, 7);
            if (choice == 1)
            {
                animator.SetTrigger("HadokenFirstWave");
                //Debug.Log($"HadokenFirstWave{Time.frameCount}");
            }
            else if (choice == 2)
            {
                animator.SetTrigger("Jump");
                //Debug.Log($"Jump{Time.frameCount}");
            }
            else if (choice == 3)
            {
                animator.SetTrigger("PrepareDropKick");
                //Debug.Log($"PrepareDropKick{Time.frameCount}");
            }
            else if (choice == 4)
            {
                animator.SetTrigger("Flamethrower");
                //Debug.Log($"Flamethrower{Time.frameCount}");
            }
            else if (choice == 5)
            {
                animator.SetTrigger("FirePillar");
                //Debug.Log($"FirePillar{Time.frameCount}");
            }
            else
            {
                animator.SetTrigger("FireRain");
                //Debug.Log($"FireRain{Time.frameCount}");
            }
        }
        //isTriggering = true;
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
