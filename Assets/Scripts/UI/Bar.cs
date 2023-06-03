using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Image ImageBar;
    [SerializeField] protected Player Player;
    [SerializeField] protected EnemyMaw EnemyMaw;
    [SerializeField] protected EnemySceleton EnemySceleton;

    public void OnFillChanged(float value, float maxValue)
    {
        ImageBar.fillAmount = value / maxValue;
    }
}
