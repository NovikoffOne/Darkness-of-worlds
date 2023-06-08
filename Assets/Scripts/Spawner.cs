using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    [SerializeField] private float _minSpawnPositionX = 15;
    [SerializeField] private float _maxSpawnPositionX = 80;
    [SerializeField] private float _minSpawnPositionZ = 10;
    [SerializeField] private float _maxSpawnPositionZ = 50;
    
    private Wave _currentWave;

    private int _currentNumberWave = 0;
    private int _spawned = 0;
    private float _timeAfterLastSpawn;

    public event UnityAction AllEnemySpawned;

    private void Start()
    {
        SetWave(_currentNumberWave);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= AssignDelay())
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if(_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentNumberWave + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentNumberWave);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        int index = Random.Range(0, _currentWave.Template.Length);
        EnemyEnity enemy = Instantiate(_currentWave.Template[index], AssignPosition(), _spawnPoint.rotation, _spawnPoint).GetComponent<EnemyEnity>();
        enemy.Init(_player);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[_currentNumberWave];
    }

    private float AssignDelay()
    {
        float delay = Random.Range(_currentWave.MinDelay, _currentWave.MaxDelay);
        return delay;
    }

    private Vector3 AssignPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(_minSpawnPositionX, _maxSpawnPositionX), 0, 
            Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ));
        return spawnPosition;
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] Template;
    public float MaxDelay;
    public float MinDelay;
    public int Count;
}
