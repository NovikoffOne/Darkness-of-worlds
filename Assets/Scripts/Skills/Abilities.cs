using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SwordsEarthSpell))]
[RequireComponent(typeof(HundredKnivesSpell))]
[RequireComponent(typeof(CircleOfFireSpell))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(AnimationState))]

public class Abilities : MonoBehaviour
{
    private Player _player;
    private AnimationState _animationState;

    #region HillVariables
    [SerializeField] private float _recoveryTreatment = 5f;
    [SerializeField] private float _waitForSecondsRecoveryTreatment = 1f;

    private bool _isStartRealoadHealingValue = false;
    #endregion

    private Spell _swordsEarthSpell;
    private Spell _hundredKnivesSpell;
    private Spell _circleOfFireSpell;

    private void Start()
    {
        _player = GetComponent<Player>();

        _animationState = GetComponent<AnimationState>();

        _swordsEarthSpell = GetComponent<SwordsEarthSpell>();
        _hundredKnivesSpell = GetComponent<HundredKnivesSpell>();
        _circleOfFireSpell = GetComponent<CircleOfFireSpell>();
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
        _swordsEarthSpell.Use();
    }

    public void AttackSkill2()
    {
        _hundredKnivesSpell.Use();
    }

    public void AttackSkill3()
    {
        _circleOfFireSpell.Use();
    }
}
