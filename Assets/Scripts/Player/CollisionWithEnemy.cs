using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _hitParctical;
    [SerializeField] private Transform _hitPoint;

    [SerializeField] private float _maxY;
    [SerializeField] private float _minY;

    private Player _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyEnity>(out EnemyEnity enemy))
        {
            _player.ApplyDamage(enemy);
            var effect = Instantiate(_hitParctical, _hitPoint.position, _hitPoint.rotation);
        }
    }
}