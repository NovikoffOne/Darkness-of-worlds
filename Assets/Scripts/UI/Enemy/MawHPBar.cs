using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MawHPBar : Bar
{
    private void OnEnable()
    {
        EnemyMaw.HealthChanged += OnFillChanged;

        ImageBar.fillAmount = 1f;
    }

    private void OnDisable()
    {
        EnemyMaw.HealthChanged -= OnFillChanged;
    }
}
