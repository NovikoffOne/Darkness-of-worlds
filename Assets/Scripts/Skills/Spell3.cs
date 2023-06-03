using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell3 : Spell
{
    [SerializeField] private GameObject _prefab;

    private RangeZoneSpell3 _spell;

    private float _damage = 75f;

    private void Start()
    {
        _animationState = GetComponent<AnimationState>();
    }

    public override void Use()
    {
        _spell = Instantiate(_prefab, transform.position, Quaternion.identity).GetComponentInChildren<RangeZoneSpell3>();
        _spell.GetSpell(this);

        _animationState.PlaySkill3();
    }

    public override void ApllyDamage(IEnemy target)
    {
        target.TakeDamage(_damage);
    }
}
