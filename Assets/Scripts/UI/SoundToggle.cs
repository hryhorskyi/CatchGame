using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private TextMeshProUGUI _soundToggleText;
    
    private bool _active = true;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(DataKeys.SoundsState))
        {
            var soundsState = PlayerPrefs.GetString(DataKeys.SoundsState);
            if(soundsState == "0")
            {
                _active = false;
                _soundToggleText.text = "Sound: off";
            }
            else if(soundsState == "1")
            {
                _active = true;
                _soundToggleText.text = "Sound: on";
            }
        }
    }

    public void Start()
    {
        _button.onClick.AddListener(SwitchSoundState);        
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(SwitchSoundState);        
    }

    private void SwitchSoundState()
    {
        if(_active)
        {
            _active = false;
            _sounds.TurnOff();
            _soundToggleText.text = "Sound: off";
        } 
        else
        {
            _active = true;
            _sounds.TurnOn();
            _soundToggleText.text = "Sound: on";
        }
    }
}