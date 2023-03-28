using System.Collections;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public float animationTime = 2.0f;
    private bool _canAnimate = true;



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
        if (_canAnimate)
        {
            animator.SetTrigger("Walk");
            StartCoroutine(animationCooldown());
        }
    }

    public void SetAttackAnimation()
    {
        if (_canAnimate)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(animationCooldown());
        }
    }

    public void SetDieAnimation()
    {
        animator.SetTrigger("Idle");
    }

    private IEnumerator animationCooldown()
    {
        _canAnimate = false;
        yield return new WaitForSeconds(animationTime);
        _canAnimate = true;
    }
}
