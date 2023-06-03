using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AnimationState))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Abilities))]
[RequireComponent(typeof(Player))]

public class KeybordInput : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speed;

    private Abilities _abilities;
    private Animator _animator;
    private AnimationState _animationState;
    private CharacterController _characterController;
    private Player _player;

    private float _valueX;
    private float _valueY;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animationState = GetComponent<AnimationState>();
        _animator = GetComponent<Animator>();
        _abilities = GetComponent<Abilities>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if(CheckPlayerDead() == true)
            return;

        _valueX = Input.GetAxis("Horizontal");
        _valueY = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.J))
            _animationState.PlayLightAttackAnimatoin();

        if (Input.GetKeyDown(KeyCode.Space) && _animationState.IsDiving == false)
            _animationState.PlayDive();

        if (Input.GetKeyDown(KeyCode.K))
            _animationState.PlayStrongAttackAnimatoin();

        if (Input.GetKeyDown(KeyCode.U))
            _abilities.AttackSkill1();

        if (Input.GetKeyDown(KeyCode.I))
            _abilities.AttackSkill2();

        if (Input.GetKeyDown(KeyCode.O))
            _abilities.AttackSkill3();

        if (Input.GetKeyDown(KeyCode.Q))
            _abilities.Healing();

        Vector3 directon = new Vector3(_valueX * _speed * Time.deltaTime, 0, _valueY * _speed * Time.deltaTime);

        if(!_animator.GetBool(_animationState.LightAttack) && !_animator.GetBool(_animationState.StrongAttack) && !_animationState.AnimationIsPlaying)
            _characterController.Move(directon);
        
        TurnInDirectionOfTravel(directon);

        _animator.SetFloat(_animationState.SpeedAnimation, _valueX);
        _animator.SetFloat(_animationState.DirectionAnimation, _valueY);
    }

    private void TurnInDirectionOfTravel(Vector3 direction)
    {
        if(direction != Vector3.zero)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _speedRotation);
    }

    private bool CheckPlayerDead()
    {
        var playerDead = _player.PlayerDead;
        return playerDead;
    }
}
