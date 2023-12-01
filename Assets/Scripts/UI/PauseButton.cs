using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Pauser _pauser;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private GameObject _pauseWindow;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(Pause);
    }

    private void Pause()
    {
        _pauser.Pause();
        _pauseWindow.SetActive(true);
        _pauseButton.interactable = false;
    }
}