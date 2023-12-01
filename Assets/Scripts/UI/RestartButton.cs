using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private GameRestarter _gameRestarter;

    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Restart);
    }

    private void Restart()
    {
        _gameRestarter.Restart();
    }
}