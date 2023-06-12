using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructTimer : MonoBehaviour
{
    private WaitForSeconds _wait;

    public void StartTimer(float time)
    {
        _wait = new WaitForSeconds(time);

        StartCoroutine(PlayTimer());
    }

    private IEnumerator PlayTimer()
    {
        yield return _wait;

        Destroy(this.gameObject);
    }
}
