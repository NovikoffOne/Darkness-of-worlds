using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPanel : StartMenuClickHandler
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Player _player;
    [SerializeField] private float _delay = 3f;

    private void Awake()
    {
        if(_player == null)
            _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.PlayerIsDead += OnPlayerIsDead;
    }

    private void OnDisable()
    {
        _player.PlayerIsDead -= OnPlayerIsDead;
    }

    private void OnPlayerIsDead()
    {
        StartCoroutine(ActivatePanel());
    }

    private IEnumerator ActivatePanel()
    {
        yield return new WaitForSeconds(_delay);

        Time.timeScale = 0;
        _panel.SetActive(true);
    }
}
