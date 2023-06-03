using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveState : State
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private int _runAnimation = Animator.StringToHash("Run");

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(Target.transform.position);
    }

    private void OnEnable()
    {
        _navMeshAgent.enabled = true;

        _animator.SetBool(_runAnimation, true);
    }

    private void OnDisable()
    {
        _navMeshAgent.enabled = false;

        _animator.SetBool(_runAnimation, false);
    }
}
