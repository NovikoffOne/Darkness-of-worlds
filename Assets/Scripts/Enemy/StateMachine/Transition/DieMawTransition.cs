using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMaw))]

public class DieMawTransition : DieTransition
{
    protected override void Awake()
    {
        _owner = GetComponent<EnemyMaw>();
    }
}
