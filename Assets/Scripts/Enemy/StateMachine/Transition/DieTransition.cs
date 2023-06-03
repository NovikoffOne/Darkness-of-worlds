using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemySceleton))]

public class DieTransition : Transition
{
    private EnemySceleton _owner;

    private void Awake()
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
