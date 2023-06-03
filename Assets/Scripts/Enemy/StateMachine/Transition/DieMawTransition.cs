using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMaw))]

public class DieMawTransition : Transition
{
    private EnemyMaw _owner;

    private void Awake()
    {
        _owner = GetComponent<EnemyMaw>();
    }

    public void CheckHealth()
    {
        if (_owner.CurrentHealth <= 0)
        {
            NeedTransit = true;
        }
    }
}
