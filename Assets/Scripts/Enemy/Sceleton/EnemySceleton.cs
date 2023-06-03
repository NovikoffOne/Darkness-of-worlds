using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SceletonCharacteristics))]

public class EnemySceleton : MonoBehaviour, IEnemy
{
    [SerializeField] private Player _target;

    private Characteristics _characteristics;
    private DieTransition _dieTransition;

    private float _currentHealth;

    #region Animation string to hash

    private int _idleAnimation = Animator.StringToHash("Idle");
    private int _attackAnimation = Animator.StringToHash("Attack");

    public int AttackAnimation => _attackAnimation;
    public int IdleAnimation => _idleAnimation;


    #endregion

    Player IEnemy.Target => _target;
    public float CurrentHealth => _currentHealth;

    public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _characteristics = GetComponent<Characteristics>();
        _dieTransition = GetComponent<DieTransition>();
        _currentHealth = _characteristics.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _characteristics.MaxHealth);

        _dieTransition.CheckHealth();
    }

    public void Death()
    {
        gameObject.SetActive(false);

        var ragdoll = Instantiate(_characteristics.Ragdoll, transform.position, transform.rotation);
    }

    public void ApplyDamage(Player player)
    {
        player.TakeDamage(_characteristics.Damage);
    }

    public void Init(Player target)
    {
        _target = target;
    }
}