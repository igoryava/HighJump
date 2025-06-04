using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private SoundVolumeSettings _soundVolumeSettings;

    private bool _volumeOn;

    private void OnEnable()
    {
        _soundVolumeSettings.StateChanged += SwitchSprite;
        _soundVolumeSettings.BootStraped += OnBootstraped;
    }

    public void SwitchSprite(bool volumeOn)
    { 
        if (volumeOn)
        {
            _image.sprite = _offSprite;
        }
        else
        {
            _image.sprite = _onSprite;
        }
    }

    private void OnBootstraped(bool volumeOn)
    {
        if (volumeOn)
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
        _soundVolumeSettings.StateChanged -= SwitchSprite;
        _soundVolumeSettings.BootStraped -= OnBootstraped;
    }
}
