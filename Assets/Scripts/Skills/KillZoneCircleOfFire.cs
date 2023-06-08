using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestructTimer))]

public class KillZoneCircleOfFire : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    
    private Spell _spell;
    private DestructTimer _destructTimer;

    private void Start()
    {
        _destructTimer = GetComponent<DestructTimer>();

        _destructTimer.StartTimer(_delay);
    }

    public void GetSpell(Spell spell)
    {
        _spell = spell.GetComponent<CircleOfFireSpell>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyEnity>(out EnemyEnity enemy))
        {
            _spell.ApllyDamage(enemy);
        }
    }
}
