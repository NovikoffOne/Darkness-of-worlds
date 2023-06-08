using System.Collections;
using UnityEngine;

public class Spell1 : Spell
{
    [SerializeField] private GameObject _spellPrefab;
    [SerializeField] private float _coolDownSkill1 = 5f;
    [SerializeField] private float _direction = 5;

    private GameObject _spell;
    private WaitForSeconds _waitFor;

    private float _damage = 100f;
    private bool _isUsed;

    private void Start()
    {
        _coolDownSkill1 = 5f;
        _animationState = GetComponent<AnimationState>();
        _waitFor = new WaitForSeconds(_coolDownSkill1);
        _isUsed = false;
    }

    public override void Use()
    {
        if (_isUsed == false)
        {
            _animationState.PlaySkill1();

            Vector3 direction = _direction * transform.forward;

            _spell = Instantiate(_spellPrefab, transform.position + direction, transform.rotation);

            _isUsed = true;

            StartCoroutine(StartCoolDownTimer());
        }
        else
        {
            return;
        }
    }

    public override void ApllyDamage(EnemyEnity target)
    {
        target.TakeDamage(_damage);
    }

    private IEnumerator StartCoolDownTimer()
    {
        yield return _waitFor;

        _isUsed = false;
    }

    public void DestroyObjectInScen()
    {
        Destroy(_spell.gameObject);
    }
}
