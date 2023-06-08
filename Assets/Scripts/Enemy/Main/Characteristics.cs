using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private GameObject _ragdoll;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _attackRange;

    public GameObject Ragdoll => _ragdoll;

    public float ViewRadius => _viewRadius;
    public float AttackRange => _attackRange;
    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
}
