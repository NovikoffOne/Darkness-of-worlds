using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullid : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;
    [SerializeField] private float _speed = 15f;

    private float _timer;

    private void Start()
    {
        _timer = _delay;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
