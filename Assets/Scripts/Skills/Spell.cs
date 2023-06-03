using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    //[SerializeField] private GameObject _spellPrefab;
    //[SerializeField] private float _coolDownSkill1 = 5f;

    protected AnimationState _animationState;
    //private WaitForSeconds _waitFor;

    //private float _damage = 100f;
    //private bool _isUsed;

    public abstract void Use();

    public abstract void ApllyDamage(IEnemy target);
}
