using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestructTimer))]

public class KillZoneSwordsEarth : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    
    private SwordsEarthSpell _spell;
    private DestructTimer _destructTimer;

    private void Start()
    {
        _destructTimer = GetComponent<DestructTimer>();
        _destructTimer.StartTimer(_delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            return;
        }
        else if (other.TryGetComponent<EnemyEnity>(out EnemyEnity enemy))
        {
            _spell.ApllyDamage(enemy);
        }
    }

    public void Init(Transform spell)
    {
        _spell = spell.GetComponent<SwordsEarthSpell>();
    }
}
