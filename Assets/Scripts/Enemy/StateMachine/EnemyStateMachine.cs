using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Awake()
    {
        _target = GetComponent<EnemyEnity>().Target;

        if(_target == null)
            _target = FindObjectOfType<Player>();
    }

    private void Start()
    {
        Reset(_startState);
    }

    private void Update()
    {
        if(_currentState == null)
            return;

        var nextState = _currentState.GetNext();

        if(nextState != null)
            Transit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if(_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if(_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if(_currentState != null)
            _currentState.Enter(_target);
    }
}
