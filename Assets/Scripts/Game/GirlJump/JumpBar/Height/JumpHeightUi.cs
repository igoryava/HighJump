using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpHeightUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _heightText;

    [SerializeField] private LevelInfo _info;

    [SerializeField] private JumpSuccessState _successState;
    [SerializeField] private JumpSliderStats _sliderStats;

    public event Action<float> HeightCalculated;

    private void OnEnable()
    {
        _successState.Successed += OnEnd;
    }

    private void OnEnd()
    {
        float height = 10 - _sliderStats.CurrentStep;

        float calculated = (_info.Current.Height + 0.1f * height);

        _heightText.text = calculated.ToString() + "m";

        HeightCalculated?.Invoke(calculated);
    }

    private void OnDisable()
    {
        _successState.Successed -= OnEnd;
    }
}