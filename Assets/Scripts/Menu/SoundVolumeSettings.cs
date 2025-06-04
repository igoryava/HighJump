using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    [field: SerializeField] public string MixerKey {get; private set;}

    public event Action<bool> StateChanged;
    public event Action<bool> BootStraped;
    
    private bool _volumeOn;

    private void Start()
    {
        _volumeOn = Convert.ToBoolean(PlayerPrefs.GetInt("VolumeOn" + MixerKey, 1));
        if (_volumeOn)
        {
            _audioMixer.SetFloat(MixerKey, _maxValue);
            BootStraped?.Invoke(_volumeOn);
        }
        else
        {
            _audioMixer.SetFloat(MixerKey, _minValue);
            BootStraped?.Invoke(_volumeOn);
        }
    }

    public void ChangeSoundVolume()
    {
        if (!_volumeOn)
        {
            _audioMixer.SetFloat(MixerKey, _maxValue);
            PlayerPrefs.SetInt("VolumeOn" + MixerKey, 1);
            StateChanged?.Invoke(_volumeOn);
            _volumeOn = true;
        }
        else
        {
            _audioMixer.SetFloat(MixerKey, _minValue);
            PlayerPrefs.SetInt("VolumeOn"+ MixerKey, 0);
            StateChanged?.Invoke(_volumeOn);
            _volumeOn = false;
        }
    }
}
