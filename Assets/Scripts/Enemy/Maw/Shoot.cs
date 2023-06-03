using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;

    public void LaunchAProjectile()
    {
        Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
