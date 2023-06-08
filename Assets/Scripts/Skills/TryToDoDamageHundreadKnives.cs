using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(DestructTimer))]

public class TryToDoDamageHundreadKnives : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    [SerializeField] private float _speed = 15f;

    private DestructTimer _destructTimer;
    private HundredKnivesSpell _spell;

    private void Start()
    {
        _destructTimer = GetComponent<DestructTimer>();

        _destructTimer.StartTimer(_delay);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
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

    public void Init(Transform spell)
    {
        _spell = spell.GetComponent<HundredKnivesSpell>();
    }
}