using System;
using System.Collections;
using System.Collections.Generic;
using Lofelt.NiceVibrations;
using UnityEngine;
using UnityEngine.Audio;

public class VibrationSettings : MonoBehaviour
{
    [SerializeField] private HapticReceiver _hapticReceiver;
    [field: SerializeField] public string VibrationKey {get; private set;}

    public event Action<bool> StateChanged;
    public event Action<bool> BootStraped;
    
    private bool _vibrationOn;

    private void Start()
    {
        _vibrationOn = Convert.ToBoolean(PlayerPrefs.GetInt("VibrationOn" + VibrationKey, 1));
        if (_vibrationOn)
        {
            EnableHaptic(true);
            BootStraped?.Invoke(_vibrationOn);
        }
        else
        {
            EnableHaptic(false);
            BootStraped?.Invoke(_vibrationOn);
        }
    }

    public void ChangeVibrationStrength()
    {
        if (!_vibrationOn)
        {
            EnableHaptic(true);
            PlayerPrefs.SetInt("VibrationOn" + VibrationKey, 1);
            StateChanged?.Invoke(_vibrationOn);
            _vibrationOn = true;
        }
        else
        {
            EnableHaptic(false);
            PlayerPrefs.SetInt("VibrationOn"+ VibrationKey, 0);
            StateChanged?.Invoke(_vibrationOn);
            _vibrationOn = false;
        }
    }

    private void EnableHaptic(bool enabled)
    {
        if (_hapticReceiver != null)
        {
            _hapticReceiver.hapticsEnabled = enabled;
        }
    }
}
