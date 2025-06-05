using System;
using System.Collections;
using System.Collections.Generic;
using Lofelt.NiceVibrations;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsLoader : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private HapticReceiver _haptic;

    private void Start()
    {
        CheckSettings();
    }

//КОСТЫЛЬ МОЙ
    private void CheckSettings()
    {
        if (PlayerPrefs.GetInt("VolumeOn" + "SoundVolume", 1) == 0)
        {
            _mixer.SetFloat("SoundVolume", -80f);
        }

        if (PlayerPrefs.GetInt("VolumeOn" + "MusicVolume", 1) == 0)
        {
            _mixer.SetFloat("MusicVolume", -80f);
        }

        if (PlayerPrefs.GetInt("VibrationOn" + "Vibration", 1) == 0)
        {
            _haptic.enabled = false;
        }
    }
}