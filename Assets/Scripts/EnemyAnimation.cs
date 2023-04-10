using System.Collections;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Player _player;
    private float damage = 20;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
        
    public void SetIdleAnimation()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Idle", true);
    }

    public void SetWalkAnimation()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", true);
    }

    public void SetAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void AttackAnimationEvent()
    {
        _player.TakeDamage(damage);
    }

    public void SetDieAnimation()
    {
        animator.SetTrigger("Die");
    }
}
