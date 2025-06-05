using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameSliderStatsUI : MonoBehaviour
{
    [SerializeField] private MinIGameSliderStats _minIGameSliderStats;
    [SerializeField] private Image _gradeImage;
    [SerializeField] private Sprite _bad;
    [SerializeField] private Sprite _good;
    [SerializeField] private Sprite _perfect;

    private void OnEnable()
    {
        _minIGameSliderStats.SliderChanged += OnGradeChanged;
    }

    private void OnGradeChanged(int grade)
    {
        switch (grade)
        {
            case 1:
                _gradeImage.sprite = _perfect;
                break;
            case 2:
                _gradeImage.sprite = _good;
                break;
            case 3:
                _gradeImage.sprite = _bad;
                break;
        }
    }

    private void OnDisable()
    {
        _minIGameSliderStats.SliderChanged -= OnGradeChanged;
    }
}
