using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellControlls2 : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    [SerializeField] private float _speed = 15f;

    private Spell2 _spell;
    private float _timer;
    private Vector3 _direction;

    private void Start()
    {
       _spell = FindObjectOfType<Spell2>().GetComponent<Spell2>();

        _timer = _delay;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
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
            Destroy(gameObject);
        }
    }

    public void GoTarget(Vector3 direction  )
    {
        _direction = direction;
    }
}
