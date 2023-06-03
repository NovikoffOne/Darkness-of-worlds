using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[RequireComponent(typeof(EnemyMaw))]

public class AttackMawState : State
{
    private EnemyMaw _owner;
    private Animator _animator;

    private void Awake()
    {
        _owner = GetComponent<EnemyMaw>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    { 
            _owner.Shoot();
    }

    public override void Exit()
    {
        base.Exit();

        _animator.SetBool(_owner.RangeAttackAnimation, false);
    }
}
