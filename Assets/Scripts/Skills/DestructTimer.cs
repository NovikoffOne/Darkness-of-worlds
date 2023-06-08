using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructTimer : MonoBehaviour
{
    private float _timer = 0;

    private void Update()
    {
        if (_timer < 0)
            return;
        
        _timer -= Time.deltaTime;

        if (_timer <= 0)
            Destroy(this.gameObject);
    }

    public void StartTimer(float time)
    {
        _timer = time;
    }
}
