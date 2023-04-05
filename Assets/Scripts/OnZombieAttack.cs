using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnZombieAttack : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyChasing>().isAttacking = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyChasing>().isAttacking = false;
    }
}
