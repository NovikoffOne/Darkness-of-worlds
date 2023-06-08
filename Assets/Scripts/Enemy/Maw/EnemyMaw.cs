using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Characteristics))]
[RequireComponent(typeof(DieMawTransition))]

public class EnemyMaw : EnemyEnity
{
    private Animator _animator;

    #region Animation string to hash

    private int _idleAnimation = Animator.StringToHash("Idle");
    private int _rangeAttackAnimation = Animator.StringToHash("RangeAttack");
    private int _meleeAttackAnimation = Animator.StringToHash("MeleeAttack");

    public int MeleeAttackAnimation => _meleeAttackAnimation;
    public int RangeAttackAnimation => _rangeAttackAnimation;
    public int IdleAnimation => _idleAnimation;
    
    #endregion

    private void Start()
    {
        _characteristics = GetComponent<Characteristics>();
        _animator = GetComponentInChildren<Animator>();
        _dieTransition = GetComponent<DieMawTransition>();

        _currentHealth = _characteristics.MaxHealth;
    }

    public void Shoot()
    {
        if (IsAnimationPlaying(RangeAttackAnimation.ToString()) == false)
        {
            LookAtTarget();
            _animator.SetBool(RangeAttackAnimation, true);
        }
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }

    private void LookAtTarget()
    {
        transform.LookAt(_target.transform.position);
    }
}
