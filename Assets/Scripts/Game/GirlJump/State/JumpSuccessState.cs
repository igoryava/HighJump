using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSuccessState : MonoBehaviour
{
    [SerializeField] private int _minStepsToSuccess;
    [SerializeField] private int _maxStepsToSuccess;

    [SerializeField] private JumpSliderStats _sliderStats;

    public event Action Successed;
    public event Action Failed;
    public event Action FailedOver;

    private void OnEnable()
    {
        _sliderStats.StepsCalculated += OnStepsCalculated;
    }

    private void OnStepsCalculated(int value)
    {
        if (value >= _minStepsToSuccess)
        {
            if (value <= _maxStepsToSuccess)
            {
                Successed?.Invoke();
                return;
            }

            FailedOver?.Invoke();
            return;
        }

        Failed?.Invoke();
    }

    private void OnDisable()
    {
        _sliderStats.StepsCalculated -= OnStepsCalculated;
    }
}