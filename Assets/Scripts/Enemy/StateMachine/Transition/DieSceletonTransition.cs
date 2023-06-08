using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceletonCharacteristics))]
[RequireComponent(typeof(EnemySceleton))]

public class DieSceletonTransition : DieTransition
{
    protected override void Awake()
    {
        base.Awake();
    }
}
