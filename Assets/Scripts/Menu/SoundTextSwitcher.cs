using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundTextSwitcher : MonoBehaviour
{
    [SerializeField] private string _onText;
    [SerializeField] private string _offText;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private SoundVolumeSettings _soundVolumeSettings;

    private bool _volumeOn;

    private void OnEnable()
    {
        _soundVolumeSettings.StateChanged += SwitchText;
        _soundVolumeSettings.BootStraped += OnBootstraped;
    }

    public void SwitchText(bool volumeOn)
    { 
        if (volumeOn)
        {
            _text.text = _offText;
        }
        else
        {
            _text.text = _onText;
        }
    }

    private void OnBootstraped(bool volumeOn)
    {
        if (volumeOn)
        {
            _text.text = _onText;
        }
        else
        {
            _text.text = _offText;
        }
    }

    private void OnDisable()
    {
        _soundVolumeSettings.StateChanged -= SwitchText;
        _soundVolumeSettings.BootStraped -= OnBootstraped;
    }
}
