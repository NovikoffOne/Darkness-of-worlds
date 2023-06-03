using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeZoneSpell3 : MonoBehaviour
{
    private Spell _spell;

    public void GetSpell(Spell spell)
    {
        _spell = spell;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            _spell.ApllyDamage(enemy);
        }
    }
}
