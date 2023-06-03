using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class MawPatrolState : State
{
    private EnemyMaw _owner;
    private Animator _animator;

    private void Awake()
    {
        _owner = GetComponent<EnemyMaw>();
        _animator = GetComponentInChildren<Animator>();
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
