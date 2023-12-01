using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField]
    private Pauser _pauser;
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private GameObject _pauseWindow;
    private void Awake()
    {
        _resumeButton.onClick.AddListener(Unpause);
    }

    private void OnDestroy()
    {
        _resumeButton.onClick.RemoveListener(Unpause);
    }

    private void Unpause()
    {
        _pauser.Unpause();
        _pauseWindow.SetActive(false);
        _pauseButton.interactable = true;
    }
}