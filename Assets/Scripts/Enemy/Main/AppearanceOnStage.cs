using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppearanceOnStage : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particalePrefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _offset = 2.5f;

    private ParticleSystem _particale;
    private float _timer = 0;

    private void Start()
    {
        var position = transform.position + Vector3.up * _offset;

        _particale = Instantiate(_particalePrefab, position, Quaternion.identity);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= _delay)
        {
            _particale.gameObject.SetActive(false);
        }
    }
}
