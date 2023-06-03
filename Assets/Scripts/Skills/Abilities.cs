using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Spell1))]
[RequireComponent(typeof(Spell2))]
[RequireComponent(typeof(Spell3))]

public class Abilities : MonoBehaviour
{
    private Player _player;
    private AnimationState _animationState;

    #region HillVariables
    [SerializeField] private float _recoveryTreatment = 5f;
    [SerializeField] private float _waitForSecondsRecoveryTreatment = 1f;

    private bool _isStartRealoadHealingValue = false;
    #endregion

    private Spell _spell1;
    private Spell _spell2;
    private Spell _spell3;

    private void Start()
    {
        _player = GetComponent<Player>();

        _animationState = GetComponent<AnimationState>();

        _spell1 = GetComponent<Spell1>();
        _spell2 = GetComponent<Spell2>();
        _spell3 = GetComponent<Spell3>();
    }

    private void Update()
    {
        if (_player.CurrentHealingBar < _player.MaxHelingBar && _isStartRealoadHealingValue == false)
            StartCoroutine(RealoadHealingValue());
    }

    #region Hill
    public void Healing(float health = 30f)
    {
        if (_player.CurrentHealingBar < health && _player.CurrentHp < _player.MaxHp)
        {
            return;
        }
        else
        {
            _animationState.PlayHealingPlayAnimation();

            _player.RestoreHP(health);
            _player.ChangeValueBar(-health);
        }
    }

    private IEnumerator RealoadHealingValue()
    {
        WaitForSeconds waitFor = new WaitForSeconds(_waitForSecondsRecoveryTreatment);

        while (_player.CurrentHealingBar < _player.MaxHelingBar)
        {
            _isStartRealoadHealingValue = true;

            _player.ChangeValueBar(_recoveryTreatment);

            yield return waitFor;
        }

        _isStartRealoadHealingValue = false;
    }
    #endregion

    public void AttackSkill1()
    {
        _spell1.Use();
    }

    public void AttackSkill2()
    {
        _spell2.Use();
    }

    public void AttackSkill3()
    {
        _spell3.Use();
    }
}
