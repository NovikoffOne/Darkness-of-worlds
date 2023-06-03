using UnityEngine;

public class HealingBar : Bar
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        if(_player == null)
            _player = GetComponentInParent<Player>();
    }

    private void OnEnable()
    {
        _player.HealingChanged += OnFillChanged;

        ImageBar.fillAmount = 1f;
    }

    private void OnDisable()
    {
        _player.HealingChanged -= OnFillChanged;
    }
}
