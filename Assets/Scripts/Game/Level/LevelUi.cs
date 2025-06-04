using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUi : MonoBehaviour
{
    [SerializeField] private LevelInfo _info;

    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _info.Bootstrapped += OnBootstrapped;
    }

    private void OnBootstrapped()
    {
        _text.text = "Level " + _info.Current.Number;
    }

    private void OnDisable()
    {
        _info.Bootstrapped -= OnBootstrapped;
    }
}