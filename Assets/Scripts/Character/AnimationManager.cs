using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public event Action onAttackStarted;
    public event Action onHitFrame;
    public event Action onAttackFinished;

    public bool IsAttacking { get; private set; }

    public void StartAttack(int _atkId, int _currentSpeed)
    {
        animator.SetBool("Attack" + _atkId, true);
        animator.speed = 0.2f * _currentSpeed;
    }

    public void StopAttack(int _atkId)
    {
        animator.SetBool("Attack" + _atkId, false);
    }

    public void AttackStarted()
    {
        IsAttacking = true;
        onAttackStarted?.Invoke();
    }
    public void AttackHitFrame() => onHitFrame?.Invoke();
    public void AttackFinished()
    {
        animator.speed = 1;
        IsAttacking = false;
        onAttackFinished?.Invoke();
    }
}
