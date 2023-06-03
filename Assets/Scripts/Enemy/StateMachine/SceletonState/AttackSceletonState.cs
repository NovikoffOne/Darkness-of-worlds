using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSceletonState : State
{
    private Animator _animator;
    private EnemySceleton _owner;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _owner = GetComponent<EnemySceleton>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_owner.AttackAnimation, true);
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool(_owner.AttackAnimation, false);
    }
}
