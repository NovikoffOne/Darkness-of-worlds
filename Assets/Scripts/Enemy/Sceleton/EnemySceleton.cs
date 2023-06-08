using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SceletonCharacteristics))]
[RequireComponent(typeof(DieSceletonTransition))]

public class EnemySceleton : EnemyEnity
{
    #region Animation string to hash

    private int _idleAnimation = Animator.StringToHash("Idle");
    private int _attackAnimation = Animator.StringToHash("Attack");

    public int AttackAnimation => _attackAnimation;
    public int IdleAnimation => _idleAnimation;

    #endregion

    private void Start()
    {
        _characteristics = GetComponent<Characteristics>();
        _dieTransition = GetComponent<DieTransition>();
        _currentHealth = _characteristics.MaxHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Death()
    {
        base.Death();
    }

    public override void ApplyDamage(Player player)
    {
        base.ApplyDamage(player);
    }

    public override void Init(Player target)
    {
        base.Init(target);
    }
}