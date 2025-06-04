using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private VibrationSettings _vibrationSettings;

    private bool _volumeOn;

    private void OnEnable()
    {
        _vibrationSettings.StateChanged += SwitchSprite;
        _vibrationSettings.BootStraped += OnBootstraped;
    }

    public void SwitchSprite(bool vibrationOn)
    {
        if (vibrationOn)
        {
            _image.sprite = _offSprite;
        }
        else
        {
            _image.sprite = _onSprite;
        }
    }

    private void OnBootstraped(bool vibrationOn)
    {
        if (vibrationOn)
        {
            _image.sprite = _onSprite;
        }
        else
        {
            _image.sprite = _offSprite;
        }
    }

    private void OnDisable()
    {
        _vibrationSettings.StateChanged -= SwitchSprite;
        _vibrationSettings.BootStraped -= OnBootstraped;
    }
}    
