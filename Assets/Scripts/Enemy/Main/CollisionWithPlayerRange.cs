using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayerRange : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticle;
    [SerializeField] private Transform _hitPoint;

    [SerializeField] private float _damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Instantiate(_hitParticle, _hitPoint.position, _hitPoint.rotation);
            Destroy(this.gameObject);
        }
    }
}
