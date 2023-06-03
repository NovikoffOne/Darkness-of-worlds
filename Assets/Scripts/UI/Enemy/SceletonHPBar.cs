using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceletonHPBar : Bar
{
    private void OnEnable()
    {
        EnemySceleton.HealthChanged += OnFillChanged;

        ImageBar.fillAmount = 1f;
    }

    private void OnDisable()
    {
        EnemySceleton.HealthChanged -= OnFillChanged;
    }
}
