using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellControlls : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    
    private Spell1 _spell;

    private float _timer;

    private void Start()
    {
        _spell = FindObjectOfType<Spell1>().GetComponent<Spell1>();

        _timer = _delay;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _spell.DestroyObjectInScen();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            return;
        }
        else if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            _spell.ApllyDamage(enemy);
        }
    }
}
