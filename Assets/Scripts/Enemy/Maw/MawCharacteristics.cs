using UnityEngine;

public class MawCharacteristics : Characteristics
{
    [SerializeField] private float _meleeAttackDistance = 2.5f;

    public float MeleeAttackDistance => _meleeAttackDistance;
}
