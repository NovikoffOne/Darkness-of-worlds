using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyEnity : MonoBehaviour
{
    protected Player _target;
    protected Characteristics _characteristics;
    protected DieTransition _dieTransition;
    protected float _currentHealth;

    public float CurrentHealth => _currentHealth;

    public event UnityAction<float, float> HealthChanged;
    
    public Player Target => _target;

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _characteristics.MaxHealth);

        if(_dieTransition != null)
        {
            _dieTransition.CheckHealth();
        }
    }

    public virtual void ApplyDamage(Player player)
    {
        player.TakeDamage(_characteristics.Damage);
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);

        var ragdoll = Instantiate(_characteristics.Ragdoll, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }

    public virtual void Init(Player target)
    {
        _target = target;
    }
}
