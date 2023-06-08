using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationState))]

public class CircleOfFireSpell : Spell
{
    [SerializeField] private GameObject _prefab;

    private KillZoneCircleOfFire _spell;

    private float _damage = 75f;

    private void Start()
    {
        _animationState = GetComponent<AnimationState>();
    }

    public override void Use()
    {
        _spell = Instantiate(_prefab, transform.position, Quaternion.identity).GetComponentInChildren<KillZoneCircleOfFire>();
        _spell.GetSpell(this);

        _animationState.PlaySkill3();
    }

    public override void ApllyDamage(EnemyEnity target)
    {
        target.TakeDamage(_damage);
    }
}
