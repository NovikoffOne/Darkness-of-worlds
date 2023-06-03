using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : Spell
{
    [SerializeField] private GameObject _spellPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _coolDownSkill1 = 5f;
    [SerializeField] private float _damage = 50f;

    private WaitForSeconds _waitFor;

    private bool _isUsed;

    private void Start()
    {
        _animationState = GetComponent<AnimationState>();
        _waitFor = new WaitForSeconds(_coolDownSkill1);
        _isUsed = false;
    }

    public override void Use()
    {
        if (_isUsed == false)
        {
            Vector3 direction = transform.forward + transform.position;

            _animationState.PlaySkill2();

            var skill = Instantiate(_spellPrefab, _spawnPoint.position, transform.rotation);

           // skill.GetComponent<SpellControlls2>().GoTarget(direction);

            _isUsed = true;

            StartCoroutine(StartCoolDownTimer());
        }
    }

    public override void ApllyDamage(IEnemy target)
    {
        target.TakeDamage(_damage);
    }

    private IEnumerator StartCoolDownTimer()
    {
        yield return _waitFor;

        _isUsed = false;
    }
}
