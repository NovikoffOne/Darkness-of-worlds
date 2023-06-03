using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationState : MonoBehaviour
{
    #region StringToHash Animations

    private int[] _deathAnimation;
    private int _death1 = Animator.StringToHash("Death1");
    private int _death2 = Animator.StringToHash("Death2");
    private int _death3 = Animator.StringToHash("Death3");

    private int[] _takeDamageAnimation;
    private int _impact1 = Animator.StringToHash("Impact1");
    private int _impact2 = Animator.StringToHash("Impact2");
    private int _impact3 = Animator.StringToHash("Impact3");

    private int _lightAttack = Animator.StringToHash("LightAttack");
    private int _strongAttack = Animator.StringToHash("StrongAttack");
    private int _dive = Animator.StringToHash("Dive");
    private int _hill = Animator.StringToHash("Hill");

    private int _speedAnimation = Animator.StringToHash("Speed");
    private int _direction = Animator.StringToHash("Direction");

    private int _skill1 = Animator.StringToHash("Skill1");
    private int _skill2 = Animator.StringToHash("Skill2");
    private int _skill3 = Animator.StringToHash("Skill3");

    public int LightAttack => _lightAttack;
    public int StrongAttack => _strongAttack;
    public int SpeedAnimation => _speedAnimation;
    public int DirectionAnimation => _direction;

    #endregion

    private Animator _animator;

    private bool _isDiving = false;
    private bool _animationIsPlaying = false;

    public bool IsDiving { get { return _isDiving; }}
    public bool AnimationIsPlaying { get { return _animationIsPlaying; } }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _deathAnimation = new int[3] { _death1, _death2, _death3 };
        _takeDamageAnimation = new int[3] { _impact1, _impact2, _impact3 };
    }

    public void PlayLightAttackAnimatoin()
    {
        _animator.SetTrigger(_lightAttack);
        _animationIsPlaying = true;
    }

    public void PlayStrongAttackAnimatoin()
    {
        _animator.SetTrigger(_strongAttack);
        _animationIsPlaying = true;
    }

    public void PlayDive()
    {
        _animator.SetTrigger(_dive);
        _isDiving = true;
    }

    public void PlayHealingPlayAnimation()
    {
        _animator.SetTrigger(_hill);
        _animationIsPlaying = true;
    }

    public void PlayDeath()
    {
        int randomAnimation = UnityEngine.Random.Range(0, _deathAnimation.Length);

        _animator.Play(_deathAnimation[randomAnimation]);

        _animationIsPlaying = true;
    }

    public void PlayTakeDamage()
    {
        int randomAnimation = UnityEngine.Random.Range(0, _takeDamageAnimation.Length);

        _animator.Play(_takeDamageAnimation[randomAnimation]);
    }

    public void PlaySkill1()
    {
        _animator.SetTrigger(_skill1);
        _animationIsPlaying = true;
    }

    public void PlaySkill2()
    {
        _animator.SetTrigger(_skill2);
        _animationIsPlaying = true;
    }
    
    public void PlaySkill3()
    {
        _animator.SetTrigger(_skill3);
        _animationIsPlaying = true;
    }

    public void AllowDiving()
    {
        _isDiving = false;
    }

    public void AllowAnimationPlaying()
    {
        _animationIsPlaying = false;
    }
}