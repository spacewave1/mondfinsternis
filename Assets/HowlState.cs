using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HowlState : StateMachineBehaviour {

    public AudioClip howlClip;
    
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<AudioSource>().clip = howlClip;
        animator.GetComponent<AudioSource>().Play();
        if(animator.GetBool("playerDead") == false)
        {
            if(animator.GetComponent<WolfBehaviour>().speed > 5f)
            {
                animator.SetBool("isRunning", true);
            } else if(animator.GetComponent<WolfBehaviour>().speed > 5f)
            {
                animator.SetBool("isWalking", true);
            }
            
            animator.SetFloat("speed", animator.GetComponent<WolfBehaviour>().speed);
        } else
        {
            animator.SetTrigger("eat");
        } 
        
        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

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
