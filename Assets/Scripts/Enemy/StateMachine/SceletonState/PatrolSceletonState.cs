using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PatrolSceletonState : State
{
    private Animator _animator;
    private EnemySceleton _owner;

    private void Awake()
    {
        _owner = GetComponent<EnemySceleton>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_owner.IdleAnimation, true);
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool(_owner.IdleAnimation, false);
    }
}
