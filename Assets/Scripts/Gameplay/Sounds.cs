using System;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _coinSound;
    private bool _active = true;

    private void Start()
    {
        if(PlayerPrefs.HasKey(DataKeys.SoundsState))
        {
            var soundsState = PlayerPrefs.GetString(DataKeys.SoundsState);
            if(soundsState == "0")
                TurnOff();
            else if(soundsState == "1")
                TurnOn();
        }
        else
        {
            PlayerPrefs.SetString(DataKeys.SoundsState, "1");
        }
    }

    public void Pause()
    {
        _audioSource.Pause();
    }

    public void TurnOff()
    {
        _active = false;
        _audioSource.Pause();
        PlayerPrefs.SetString(DataKeys.SoundsState, "0");
    }

    public void TurnOn()
    {
        _active = true;
        _audioSource.Play();
        PlayerPrefs.SetString(DataKeys.SoundsState, "1");
    }

    public void PlayCoinSound()
    {
        if(!_active)
            return;
        
        _audioSource.PlayOneShot(_coinSound);
    }
}