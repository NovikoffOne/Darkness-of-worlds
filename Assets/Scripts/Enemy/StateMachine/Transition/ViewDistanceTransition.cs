using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDistanceTransition : Transition
{
    private Characteristics _characteristics;

    private void Awake()
    {
        _characteristics = GetComponent<Characteristics>();
    }

    private void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, Target.transform.position);

        if (targetDistance <= _characteristics.ViewRadius && targetDistance > _characteristics.AttackRange)
            NeedTransit = true;
    }
}
