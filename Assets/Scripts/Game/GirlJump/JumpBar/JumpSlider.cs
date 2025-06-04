using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpSlider : MonoBehaviour
{
    [SerializeField] private JumpBar _bar;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _moveTime;

    [SerializeField] private Ease _ease;

    private Tween _moveTween;


    private void OnEnable()
    {
        _bar.Start += OnStart;
        _bar.Released += OnReleased;
    }

    private void OnStart()
    {
        _moveTween = transform.DOMoveX(_targetPoint.position.x, _moveTime).SetEase(_ease);
    }

    private void OnReleased()
    {
        _moveTween.Kill();
    }


    private void OnDisable()
    {
        _bar.Start -= OnStart;
        _bar.Released -= OnReleased;
    }
}