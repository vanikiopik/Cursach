using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleAnimation()
    {
        animator.SetTrigger("Idle");
    }

    public void SetWalkAnimation()
    {
        animator.SetTrigger("Walk");
    }

    public void SetAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void SetDieAnimation()
    {

    }
}
