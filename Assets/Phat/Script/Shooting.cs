using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : StateMachineBehaviour
{
    private Attack attack;
    private Dash dashing;
    private Movement move;
    private WallMove wall;
    private ChargeAttack charge;
    [System.NonSerialized] public Vector3 shootPosition;
    private VFXList vfx;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vfx = animator.GetComponent<VFXList>();
        charge = animator.GetComponent<ChargeAttack>();
        wall = animator.GetComponent<WallMove>();
        move = animator.GetComponent<Movement>();
        dashing = animator.GetComponent<Dash>();
        attack = animator.GetComponent<Attack>();
        Shoot();
        var g = VFXPlayer.PlayAnimation(charge.shootVFX, shootPosition, vfx.vfxPrefab[charge.chargeLevel].transform.rotation);
        g.transform.SetParent(GameObject.Find("Player").transform);      
        if(!wall.slidingWall)
        {
            g.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            g.transform.localScale = new Vector3(-1, 1, 1);
        }
        Destroy(g, vfx.vfxClip[charge.chargeLevel].length);
        if (shootPosition == attack.busterDash.transform.position)
            Debug.Log("dash shoot");
    }

    private void Shoot()
    {
        if ((move.rb.velocity.y > 0 || move.rb.velocity.y < 0) && !wall.slidingWall)
        {
            Instantiate(charge.bullet, attack.busterJump.transform.position, attack.buster.transform.rotation);
            shootPosition = attack.busterJump.transform.position;
        }
        if (dashing.isDashing)
        {
            Instantiate(charge.bullet, attack.busterDash.transform.position, attack.buster.transform.rotation);
            shootPosition = attack.busterDash.transform.position;
        }
        if (wall.slidingWall)
        {
            Instantiate(charge.bullet, attack.busterWall.transform.position, attack.buster.transform.rotation);
            shootPosition = attack.busterWall.transform.position;
        }
        else if (move.onGround && !dashing.isDashing)
        {
            Instantiate(charge.bullet, attack.buster.transform.position, attack.buster.transform.rotation);
            shootPosition = attack.buster.transform.position;
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
