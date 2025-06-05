using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MinIGameSliderStats : MonoBehaviour
{
    [SerializeField] private Collider2D _slider;

    private CompositeDisposable _disposable = new CompositeDisposable();
    private int _currentGrade;

    public event Action<int> SliderChanged;

    private void OnEnable()
    {
        _slider.OnTriggerEnter2DAsObservable().Subscribe(other =>
        {
            if (other.TryGetComponent<SliderGrade>(out SliderGrade grade))
            {
                _currentGrade = grade.Grade;
                SliderChanged?.Invoke(_currentGrade);
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
