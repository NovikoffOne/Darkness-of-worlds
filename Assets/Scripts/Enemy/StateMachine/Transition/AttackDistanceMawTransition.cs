using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistanceMawTransition : Transition
{
    private MawCharacteristics _characteristics;

    private void Awake()
    {
        _characteristics = GetComponent<MawCharacteristics>();
    }

    private void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, Target.transform.position);

        if (targetDistance <= _characteristics.ViewRadius && targetDistance <= _characteristics.AttackRange && targetDistance >= _characteristics.MeleeAttackDistance)
            NeedTransit = true;
    }
}
