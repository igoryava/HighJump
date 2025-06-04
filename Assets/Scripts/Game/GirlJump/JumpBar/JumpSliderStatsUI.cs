using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpSliderStatsUI : MonoBehaviour
{
    [SerializeField] private JumpSliderStats _sliderStats;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _sliderStats.StepsCalculated += OnStepsCalculated;
    }

    private void OnStepsCalculated(int value)
    {
        _text.text = value + "/10";
    }

    private void OnDisable()
    {
        _sliderStats.StepsCalculated -= OnStepsCalculated;
    }
}