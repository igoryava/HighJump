using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class JumpSliderStats : MonoBehaviour
{
    [SerializeField] private JumpBar _jumpBar;

    [SerializeField] private Collider2D _slider;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public int CurrentStep { get; private set; }

    public event Action<int> StepsCalculated;

    private void OnEnable()
    {
        _slider.OnTriggerEnter2DAsObservable().Subscribe(other =>
        {
            if (other.TryGetComponent<SliderStep>(out SliderStep step))
            {
                CurrentStep = step.Value;
            }
        }).AddTo(_disposable);

        _jumpBar.Released += OnReleased;
    }

    private void OnReleased()
    {
        StepsCalculated?.Invoke(CurrentStep);
        Debug.Log(CurrentStep);
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _jumpBar.Released -= OnReleased;
    }
}