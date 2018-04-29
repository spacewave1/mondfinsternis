using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour {

    public AudioClip attackClip;

    private NavMeshAgent navMeshAgent;
    private Transform target;
    private Transform targetHand;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        targetHand = animator.GetComponent<WolfBehaviour>().targetHand;
        //animator.transform.SetParent(targetHand);
        //animator.GetComponent<NavMeshAgent>().enabled = false;
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        target = animator.GetComponent<WolfBehaviour>().target;
        animator.SetBool("isRunning", false);
        animator.GetComponent<AudioSource>().clip = attackClip;
        if (!animator.GetComponent<AudioSource>().isPlaying) animator.GetComponent<AudioSource>().Play();
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(navMeshAgent.pathPending);
        if ((target.position - animator.transform.position).magnitude > 10)
        {
            animator.SetBool("isAttacking", false);
            animator.SetFloat("speed", animator.GetComponent<WolfBehaviour>().speed);
            animator.SetTrigger("run");
            navMeshAgent.SetDestination(target.position);
        }
        Debug.Log("is Running");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
