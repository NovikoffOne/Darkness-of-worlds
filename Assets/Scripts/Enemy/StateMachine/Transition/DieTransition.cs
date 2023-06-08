using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DieTransition : Transition
{
    protected EnemyEnity _owner;

    protected virtual void Awake()
    {
        _owner = GetComponent<EnemySceleton>();
    }

    public void CheckHealth()
    {
        if (_owner.CurrentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
