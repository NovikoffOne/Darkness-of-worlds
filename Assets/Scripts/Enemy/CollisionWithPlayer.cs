using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private GameObject _hitParticle;

    private IEnemy _owner;

    private void Start()
    {
        _owner = GetComponentInParent<IEnemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            var effect = Instantiate(_hitParticle, _hitPoint.position, _hitPoint.rotation);
            _owner.ApplyDamage(player);
        }
    }
}
