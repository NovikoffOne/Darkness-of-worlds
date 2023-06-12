using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimationState))]

public class Player : MonoBehaviour
{
    #region Variabls

    [SerializeField] private float _meleeDamage = 20f;
    [SerializeField] private float _criticalHit = 3f;

    private AnimationState _animationState;

    private float _currentHealingBar;
    private float _maxHealingBar = 100f;

    private float _maxHp = 100f;
    private float _currentHp;

    private bool _playerDead = false;
    
    public event UnityAction PlayerIsDead;
    
    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<float, float> HealingChanged;

    public float MaxHp { get { return _maxHp; } }
    public float CurrentHp { get { return _currentHp; } }
    public float CurrentHealingBar { get { return _currentHealingBar; } }
    public float MaxHelingBar { get { return _maxHealingBar; } }
    public bool PlayerDead { get { return _playerDead; } }

    #endregion

    private void Start() 
    {
        _currentHp = _maxHp;
        _currentHealingBar = _maxHealingBar;

        _animationState = GetComponent<AnimationState>();
    }

    public void TakeDamage(float damage)
    {
        if(_playerDead == false)
        {
            _currentHp -= damage;
            HealthChanged?.Invoke(_currentHp, _maxHp);

            if (damage > _maxHp / _criticalHit)
                _animationState.PlayTakeDamage();

            if (_currentHp <= 0)
                Death();
        }
    }

    public void ApplyDamage(EnemyEnity target)
    {
        if (_playerDead == false)
            target.TakeDamage(_meleeDamage);
    }

    public void RestoreHP(float point)
    {
        if (_playerDead == false)
        {
            _currentHp += point;

            HealthChanged?.Invoke(_currentHp, _maxHp);
            HealingChanged?.Invoke(_currentHealingBar, _maxHealingBar);
        }
    }

    public void ChangeValueBar(float point)
    {
        _currentHealingBar += point;

        HealingChanged?.Invoke(_currentHealingBar, _maxHealingBar);
    }

    private void Death()
    {
        _animationState.PlayDeath();
        _playerDead = true;
        PlayerIsDead?.Invoke();
    }
}
