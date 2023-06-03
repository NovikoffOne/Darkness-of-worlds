using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : Bar
{
    private void OnEnable()
    {
        Player.HealthChanged += OnFillChanged;

        ImageBar.fillAmount = 1f;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= OnFillChanged;
    }
}
