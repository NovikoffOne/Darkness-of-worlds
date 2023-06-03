using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControlls : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 5f;
    [SerializeField] private float _force = 50f;

    private Rigidbody[] _rigidbodies;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        Push();

        StartCoroutine(RemoveFromStage());
    }

    private IEnumerator RemoveFromStage()
    {
        yield return new WaitForSeconds(_destroyTime);

        Destroy(this.gameObject);
    }

    private void Push()
    {
        foreach (var element in _rigidbodies)
        {
            element.AddForce(transform.forward * -_force, ForceMode.Impulse);
        }
    }
}
