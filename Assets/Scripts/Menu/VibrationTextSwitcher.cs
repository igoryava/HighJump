using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VibrationTextSwitcher : MonoBehaviour
{
    [SerializeField] private string _onText;
    [SerializeField] private string _offText;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private VibrationSettings _vibrationSettings;

    private bool _volumeOn;

    private void OnEnable()
    {
        _vibrationSettings.StateChanged += SwitchText;
        _vibrationSettings.BootStraped += OnBootstraped;
    }

    public void SwitchText(bool vibrationOn)
    { 
        if (vibrationOn)
        {
            _text.text = _offText;
        }
        else
        {
            _text.text = _onText;
        }
    }

    private void OnBootstraped(bool vibrationOn)
    {
        if (vibrationOn)
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
        _vibrationSettings.StateChanged -= SwitchText;
        _vibrationSettings.BootStraped -= OnBootstraped;
    }
}
