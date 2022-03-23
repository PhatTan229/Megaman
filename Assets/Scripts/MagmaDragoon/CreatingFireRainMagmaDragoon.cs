using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingFireRainMagmaDragoon : StateMachineBehaviour
{
    public float creatingDelay;
    private float nextcreatingTime;
    private EnemyProjectile risingFlame;
    private Transform creatingPosition;
    private FireRainController fireRainController;
    private Rigidbody2D rb;
    private EnemyHp hp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hp == null) hp = animator.GetComponent<EnemyHp>();
        if (rb == null) rb = animator.GetComponent<Rigidbody2D>();
        if (risingFlame == null) risingFlame = animator.GetComponent<MagmaDragoon>().risingFlame;
        if (creatingPosition == null) creatingPosition = animator.GetComponent<MagmaDragoon>().fireRainPoint;
        if (fireRainController == null) fireRainController = animator.GetComponent<MagmaDragoon>().ultimateWeapon;
        hp.invisible = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (Time.time > nextcreatingTime)
        {          
            Instantiate(risingFlame, creatingPosition.position, creatingPosition.rotation);
            nextcreatingTime = Time.time + creatingDelay;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        fireRainController.CreateFireRain();
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
