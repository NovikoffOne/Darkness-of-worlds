using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class DeathState : State
{
    private EnemyEnity _owner;

    private void Awake()
    {
        _owner = GetComponent<EnemyEnity>();
    }

    private void OnEnable()
    {
        _owner.Death();
    }
}
