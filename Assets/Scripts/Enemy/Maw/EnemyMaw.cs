using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Characteristics))]
[RequireComponent(typeof(DieMawTransition))]

public class EnemyMaw : MonoBehaviour, IEnemy
{
    private Characteristics _characteristics;
    private DieMawTransition _dieTransition;
    private Player _target;
    private Animator _animator;

    private float _currentHealth;

    #region Animation string to hash
    private int _idleAnimation = Animator.StringToHash("Idle");
    private int _rangeAttackAnimation = Animator.StringToHash("RangeAttack");
    private int _meleeAttackAnimation = Animator.StringToHash("MeleeAttack");

    public int MeleeAttackAnimation => _meleeAttackAnimation;
    public int RangeAttackAnimation => _rangeAttackAnimation;
    public int IdleAnimation => _idleAnimation;
    #endregion

    public float CurrentHealth => _currentHealth;

    Player IEnemy.Target { get => _target;}

    public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _characteristics = GetComponent<Characteristics>();
        _animator = GetComponentInChildren<Animator>();
        _dieTransition = GetComponent<DieMawTransition>();

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

        Destroy(this.gameObject);
    }

    public void ApplyDamage(Player player)
    {
        player.TakeDamage(_characteristics.Damage);
    }

    public void Shoot()
    {
        if (IsAnimationPlaying(RangeAttackAnimation.ToString()) == false)
        {
            LookAtTarget();
            _animator.SetBool(RangeAttackAnimation, true);
        }
    }

    public bool IsAnimationPlaying(string animationName)
    {
        var animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    private void LookAtTarget()
    {
        transform.LookAt(_target.transform.position);
    }
}
